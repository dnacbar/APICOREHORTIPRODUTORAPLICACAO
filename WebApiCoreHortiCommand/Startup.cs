using APPCOREHORTICOMMAND.APP;
using APPCOREHORTICOMMAND.IAPP;
using CROSSCUTTINGCOREHORTI.MIDDLEWARE;
using DATAACCESSCOREHORTICOMMAND.COMMAND;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SERVICECOREHORTICOMMAND.ISERVICE;
using SERVICECOREHORTICOMMAND.SERVICE;
using System.IO.Compression;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;
using VALIDATIONCOREHORTICOMMAND.DOMAIN;

namespace WEBAPICOREHORTICOMMAND
{
    public sealed class Startup
    {
        private IConfiguration iConfiguration { get; }
        private readonly string strCorsConfig = "hortiCorsConfig";
        public Startup(IConfiguration configuration)
        {
            iConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBHORTICONTEXT>(opt =>
            {
                opt.UseSqlServer(iConfiguration.GetConnectionString("DBHORTICONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddCors(x => x.AddPolicy(strCorsConfig, p => { p.WithHeaders("DN-MR-WASATAIN-COMMAND"); }));

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
                x.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddResponseCompression(x =>
            {
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);

            services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "WS REST - WEB API HORTI COMMAND",
                Title = "WS REST - WEB API HORTI",
                Version = "V1",
            }));

            // QUERY SERVICES
            HortiQueryRepository(services);

            // COMMAND SERVICES
            HortiCommandApplicationServices(services);
            HortiCommandRepositoryServices(services);
            HortiCommandDomainServices(services);
            HortiCommandValidationServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST - HORTI COMMAND");
                opt.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseCors(strCorsConfig);
            app.UseAuthorization();

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // CONTAINER DI - APP LAYER
        private void HortiCommandApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IClientCommandApp, ClientCommandApp>();
            services.AddScoped<IProductCommandApp, ProductCommandApp>();
            services.AddScoped<IUnitCommandApp, UnitCommandApp>();
            services.AddScoped<IUserCommandApp, UserCommandApp>();   
        }

        // CONTAINER DI - DOMAIN SERVICE
        private void HortiCommandDomainServices(IServiceCollection services)
        {
            services.AddScoped<IClientDomainService, ClientDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IUnitDomainService, UnitDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private void HortiCommandRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // CONTAINER DI - VALIDATION
        private void HortiCommandValidationServices(IServiceCollection services)
        {
            // APPLICATION
            services.AddSingleton<CreateProductSignatureValidation>();
            services.AddSingleton<DeleteProductSignatureValidation>();
            services.AddSingleton<UpdateProductSignatureValidation>();

            services.AddSingleton<CreateUnitSignatureValidation>();
            services.AddSingleton<DeleteUnitSignatureValidation>();
            services.AddSingleton<UpdateUnitSignatureValidation>();

            services.AddScoped<CreateUserSignatureValidation>();
            services.AddScoped<DeleteUserSignatureValidation>();
            services.AddScoped<UpdateUserSignatureValidation>();

            //DOMAIN SERVICE
            services.AddSingleton<ProductDomainServiceValidation>();
            services.AddSingleton<UnitDomainServiceValidation>();
            services.AddSingleton<UserDomainServiceValidation>();
        }

        // CONTAINER DI - QUERY SERVICES
        private void HortiQueryRepository(IServiceCollection services)
        {
            // REPOSITORY
            services.AddScoped<DATACOREHORTIQUERY.IQUERIES.IUserAccessRepository, DATACOREHORTIQUERY.QUERIES.UserAccessRepository>();
        }
    }
}
