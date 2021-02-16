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
            services.AddScoped<DATACOREHORTIQUERY.IQUERIES.IClientRepository, DATACOREHORTIQUERY.QUERIES.ClientRepository>();
            services.AddScoped<DATACOREHORTIQUERY.IQUERIES.IUserAccessRepository, DATACOREHORTIQUERY.QUERIES.UserAccessRepository>();
        }

        // CONTAINER DI - APP LAYER
        private static void ServiceCommandApp(IServiceCollection services)
        {
            services.AddScoped<IClientCommandApp, ClientCommandApp>();
            services.AddScoped<IDistrictCommandApp, DistrictCommandApp>();
            services.AddScoped<IProducerCommandApp, ProducerCommandApp>();
            services.AddScoped<IProductCommandApp, ProductCommandApp>();
            services.AddScoped<IUserCommandApp, UserCommandApp>();
        }

        // CONTAINER DI - DOMAIN SERVICE
        private static void ServiceCommandDomain(IServiceCollection services)
        {
            services.AddScoped<IClientDomainService, ClientDomainService>();
            services.AddScoped<IDistrictDomainService, DistrictDomainService>();
            services.AddScoped<IProducerDomainService, ProducerDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();
        }

        // CONTAINER DI - REPOSITORY LAYER
        private static void ServiceCommandRepository(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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

        
    }
}
