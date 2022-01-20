using HORTI.CORE.CROSSCUTTING.MIDDLEWARE;
using HORTICOMMAND.REPOSITORY;
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

namespace HORTIQUERY
{
    public sealed class Startup
    {
        private const string HortiCorsConfig = "HORTICORSCONFIG";
        private string[] HortiHeader = { "Content-Type", "Authorization", "DN-MR-WASATAIN-COMMAND-QUERY" };
        private IConfiguration iConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            iConfiguration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBHORTICONTEXT>(opt =>
            {
                opt.UseSqlServer(iConfiguration.GetConnectionString("DBHORTICONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddCors(x => x.AddPolicy(HortiCorsConfig, p =>
            {
                p.WithOrigins("http://localhost:4200");
                p.WithMethods("GET", "POST");
                p.WithHeaders(HortiHeader);
            }));

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

            services.AddControllers();

            StartupServices.Services(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("swagger/v1/swagger.json", "WS REST - HORTI QUERY");
                opt.RoutePrefix = string.Empty;
            });

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseNotFoundExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();
            app.UseBadGatewayExceptionMiddleware();

            app.UseRouting();
            app.UseCors(HortiCorsConfig);
            app.UseAuthorization();

            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
