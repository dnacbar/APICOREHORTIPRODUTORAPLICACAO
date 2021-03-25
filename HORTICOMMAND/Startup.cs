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

namespace HORTICOMMAND
{
    public sealed class Startup
    {
        private const string HortiCorsConfig = "HORTICORSCONFIG";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBHORTICONTEXT>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DBHORTICONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddCors(x => x.AddPolicy(HortiCorsConfig, p => { p.WithHeaders("DN-MR-WASATAIN-COMMAND"); }));

            services.AddResponseCompression(x =>
            {
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);

            services.AddControllers();

            services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "WS REST - WEB API HORTI COMMAND",
                Title = "WS REST - WEB API HORTI",
                Version = "V1",
            }));

            StartupServices.Services(services);
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
            app.UseCors(HortiCorsConfig);

            app.UseAuthorization();

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
