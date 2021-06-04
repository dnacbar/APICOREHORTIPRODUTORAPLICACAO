using HORTICOMMAND.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.SERVICE;
using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.VALIDATION.APPLICATION;
using Microsoft.Extensions.DependencyInjection;

namespace HORTICOMMAND
{
    public static class StartupServices
    {
        public static void Services(IServiceCollection service)
        {
            // QUERY SERVICES
            ServiceQueryRepository(service);

            // COMMAND SERVICES
            ServiceCommandApp(service);
            ServiceCommandRepository(service);
            ServiceCommandDomain(service);
            ServiceCommandValidation(service);
        }

        // CONTAINER DI - QUERY SERVICES
        private static void ServiceQueryRepository(IServiceCollection services)
        {
            // REPOSITORY
            services.AddScoped<HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY.IClientRepository, HORTIQUERY.REPOSITORY.ClientRepository>();
            //services.AddScoped<HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY.IUserAccessRepository, HORTIQUERY.REPOSITORY.UserAccessRepository>();
        }

        // CONTAINER DI - APP LAYER
        private static void ServiceCommandApp(IServiceCollection services)
        {
            services.AddScoped<IClientCommandApp, ClientCommandApp>();
            services.AddScoped<IDistrictCommandApp, DistrictCommandApp>();
            services.AddScoped<IProducerCommandApp, ProducerCommandApp>();
            services.AddScoped<IProductCommandApp, ProductCommandApp>();
        }

        // CONTAINER DI - DOMAIN SERVICE
        private static void ServiceCommandDomain(IServiceCollection services)
        {
            services.AddScoped<IClientDomainService, ClientDomainService>();
            services.AddScoped<IDistrictDomainService, DistrictDomainService>();
            services.AddScoped<IProducerDomainService, ProducerDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private static void ServiceCommandRepository(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // CONTAINER DI - VALIDATION
        private static void ServiceCommandValidation(IServiceCollection services)
        {
            // APPLICATION
            services.AddScoped<CreateClientSignatureValidation>();
            services.AddScoped<UpdateClientSignatureValidation>();

            services.AddScoped<CreateProducerSignatureValidation>();
            services.AddScoped<UpdateProducerSignatureValidation>();

            services.AddScoped<CreateProductSignatureValidation>();
            services.AddScoped<DeleteProductSignatureValidation>();
            services.AddScoped<UpdateProductSignatureValidation>();

            services.AddScoped<CreateDistrictSignatureValidation>();
            services.AddScoped<DeleteDistrictSignatureValidation>();
            services.AddScoped<UpdateDistrictSignatureValidation>();
        }
    }
}
