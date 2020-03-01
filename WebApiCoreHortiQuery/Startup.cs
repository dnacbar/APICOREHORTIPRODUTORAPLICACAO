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

namespace WebApiCoreHortiQuery
{
    public sealed class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBHORTICONTEXT>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DBHORTICONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            HortiQueryRepositoryServices(services);
            HortiQueryAppServices(services);
            HortiQueryValidatorServices(services);

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

            services.Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Fastest);
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Fastest);

            services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "WS REST - WEB API HORTI QUERY",
                Title = "WS REST - WEB API HORTI",
                Version = "V1",
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST - WEB API HORTI V1");
                opt.RoutePrefix = string.Empty;
            });

            app.UseLogExceptionMiddleware();

            app.UseRouting();
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
            services.AddScoped<IDiscrictRepository, DistrictRepository>();
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
        }

        // CONTAINER DI - APP LAYER
        private void HortiQueryAppServices(IServiceCollection services)
        {
            services.AddScoped<IConsultCityApp, ConsultCityApp>();
            services.AddScoped<IConsultDistrictApp, ConsultDistrictApp>();
        }

        private void HortiQueryValidatorServices(IServiceCollection services)
        {
            services.AddScoped<UserAccessSignatureValidation>();
        }
    }
}
