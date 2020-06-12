using APPCOREHORTIQUERY.APP;
using APPCOREHORTIQUERY.IAPP;
using CROSSCUTTINGCOREHORTI.MIDDLEWARE;
using DATACOREHORTICOMMAND;
using DATACOREHORTIQUERY.IQUERIES;
using DATACOREHORTIQUERY.QUERIES;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using VALIDATIONCOREHORTIQUERY;

namespace WEBAPICOREHORTIQUERY
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

            services.AddCors(x => x.AddPolicy(strCorsConfig, p => { p.WithHeaders("DN-MR-WASATAIN-QUERY"); }));

            services.AddControllers()
                    .AddJsonOptions(x =>
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
                Description = "WS REST - WEB API HORTI QUERY",
                Title = "WS REST - WEB API HORTI",
                Version = "V1",
            }));

            HortiQueryApplicationServices(services);
            HortiQueryRepositoryServices(services);
            HortiQueryValidationServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST - HORTI QUERY");
                opt.RoutePrefix = string.Empty;
            });

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();

            app.UseRouting();
            app.UseCors(strCorsConfig);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // CONTAINER DI - APP LAYER
        private void HortiQueryApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ICityQueryApp, CityQueryApp>();
            services.AddScoped<IClientQueryApp, ClientQueryApp>();
            services.AddScoped<IDistrictQueryApp, DistrictQueryApp>();
            services.AddScoped<IProducerQueryApp, ProducerQueryApp>();
            services.AddScoped<IUnitQueryApp, UnitQueryApp>();
            services.AddScoped<IUserAccessApp, UserAccessApp>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private void HortiQueryRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDiscrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
        }

        // CONTAINER DI - VALIDATION
        private void HortiQueryValidationServices(IServiceCollection services)
        {
            // TALVEZ MUDAR PARA SCOPED
            services.AddSingleton<UserAccessSignatureValidation>();
        }
    }
}
