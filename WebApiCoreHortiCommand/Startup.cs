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
using Utf8Json.AspNetCoreMvcFormatter;
using Utf8Json.Resolvers;
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

            services.AddControllers(x =>
            {
                x.OutputFormatters.Clear();
                x.OutputFormatters.Add(new JsonOutputFormatter(StandardResolver.Default));
                x.InputFormatters.Clear();
                x.InputFormatters.Add(new JsonInputFormatter(StandardResolver.Default));
            });

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
                opt.SwaggerEndpoint("swagger/v1/swagger.json", "WS REST - HORTI COMMAND");
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
            services.AddScoped<IDistrictCommandApp, DistrictCommandApp>();
            services.AddScoped<IProducerCommandApp, ProducerCommandApp>();
            services.AddScoped<IProductCommandApp, ProductCommandApp>();
            services.AddScoped<IUserCommandApp, UserCommandApp>();
        }

        // CONTAINER DI - DOMAIN SERVICE
        private void HortiCommandDomainServices(IServiceCollection services)
        {
            services.AddScoped<IClientDomainService, ClientDomainService>();
            services.AddScoped<IDistrictDomainService, DistrictDomainService>();
            services.AddScoped<IProducerDomainService, ProducerDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private void HortiCommandRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // CONTAINER DI - VALIDATION
        private void HortiCommandValidationServices(IServiceCollection services)
        {
            // APPLICATION
            services.AddScoped<CreateClientSignatureValidation>();
            services.AddScoped<UpdateClientSignatureValidation>();

            services.AddScoped<CreateProducerSignatureValidation>();
            services.AddScoped<UpdateProducerSignatureValidation>();

            services.AddScoped<CreateProductSignatureValidation>();
            services.AddScoped<DeleteProductSignatureValidation>();
            services.AddScoped<UpdateProductSignatureValidation>();


            services.AddScoped<CreateUserSignatureValidation>();
            services.AddScoped<DeleteUserSignatureValidation>();
            services.AddScoped<UpdateUserSignatureValidation>();

            //DOMAIN SERVICE
            services.AddScoped<CreateClientDomainServiceValidation>();
            services.AddScoped<UpdateClientDomainServiceValidation>();

            services.AddScoped<CreateDistrictDomainServiceValidation>();
            services.AddScoped<UpdateDistrictDomainServiceValidation>();

            services.AddScoped<CreateProducerDomainServiceValidation>();
            services.AddScoped<UpdateProducerDomainServiceValidation>();

            services.AddScoped<CreateProductDomainServiceValidation>();
            services.AddScoped<UpdateProductDomainServiceValidation>();

            services.AddScoped<CreateUserDomainServiceValidation>();
            services.AddScoped<UpdateUserDomainServiceValidation>();

        }

        // CONTAINER DI - QUERY SERVICES
        private void HortiQueryRepository(IServiceCollection services)
        {
            // REPOSITORY
            services.AddScoped<DATACOREHORTIQUERY.IQUERIES.IClientRepository, DATACOREHORTIQUERY.QUERIES.ClientRepository>();
            services.AddScoped<DATACOREHORTIQUERY.IQUERIES.IUserAccessRepository, DATACOREHORTIQUERY.QUERIES.UserAccessRepository>();
        }
    }
}
