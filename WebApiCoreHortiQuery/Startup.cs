using APPCOREHORTIQUERY;
using APPCOREHORTIQUERY.INTERFACES;
using DataAccessCoreHortiCommand;
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
using WEBAPICOREHORTIQUERY.MIDDLEWARE;

namespace WebApiCoreHortiQuery
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

            services.AddCors(x => x.AddPolicy(strCorsConfig, p => { p.WithHeaders("DN-MR-WASATAIN"); }));

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

            HortiQueryRepositoryServices(services);
            HortiQueryAppServices(services);
            HortiQueryValidatorServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST - WEB API HORTI V1");
                opt.RoutePrefix = string.Empty;
            });

            app.UseLogExceptionMiddleware();
            app.UseValidationExceptionMiddleware();

            app.UseRouting();
            app.UseCors(strCorsConfig);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // CONTAINER DI - REPOSITORY LAYER
        private void HortiQueryRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDiscrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
        }

        // CONTAINER DI - APP LAYER
        private void HortiQueryAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserAccessApp, UserAccessApp>();
            services.AddScoped<IConsultCityApp, ConsultCityApp>();
            services.AddScoped<IConsultDistrictApp, ConsultDistrictApp>();
        }

        // CONTAINER DI - VALIDATOR
        private void HortiQueryValidatorServices(IServiceCollection services)
        {
            services.AddSingleton<UserAccessSignatureValidation>();
        }
    }
}
