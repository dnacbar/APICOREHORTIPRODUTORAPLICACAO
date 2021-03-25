using HORTIQUERY.APP;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.REPOSITORY;
using Microsoft.Extensions.DependencyInjection;

namespace HORTIQUERY
{
    public static class StartupServices
    {
        public static void Services(IServiceCollection service)
        {
            ServicesApp(service);
            ServicesRepository(service);
            ServicesValidation(service);
        }

        // CONTAINER DI - APP LAYER
        private static void ServicesApp(IServiceCollection services)
        {
            services.AddScoped<ICityQueryApp, CityQueryApp>();
            services.AddScoped<IClientQueryApp, ClientQueryApp>();
            services.AddScoped<IDistrictQueryApp, DistrictQueryApp>();
            services.AddScoped<IProducerQueryApp, ProducerQueryApp>();
            services.AddScoped<IUnitQueryApp, UnitQueryApp>();
            //services.AddScoped<IUserAccessApp, UserAccessApp>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private static void ServicesRepository(IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDiscrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
           // services.AddScoped<IUserAccessRepository, UserAccessRepository>();
        }

        // CONTAINER DI - VALIDATION
        private static void ServicesValidation(IServiceCollection services)
        {
            // TALVEZ MUDAR PARA SCOPED
            //services.AddScoped<UserAccessSignatureValidation>();
        }
    }
}
