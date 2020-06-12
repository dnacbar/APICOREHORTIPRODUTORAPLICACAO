using CROSSCUTTINGCOREHORTI.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DOMAINCOREHORTICOMMAND;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly ProductDomainServiceValidation _productDomainServiceValidation;
        private readonly IProductRepository _productRepository;

        public ProductDomainService(ProductDomainServiceValidation productDomainServiceValidation,
                                    IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productDomainServiceValidation = productDomainServiceValidation;
        }

        public async Task ProductServiceCreate(Product product)
        {
            _productDomainServiceValidation.ValidateHorti(product);

            await _productRepository.CreateProduct(product);
        }

        public async Task ProductServiceDelete(Product product)
        { 
            await _productRepository.DeleteProduct(product);
        }

        public async Task ProductServiceUpdate(Product product)
        {
            _productDomainServiceValidation.ValidateHorti(product);

            await _productRepository.UpdateProduct(product);
        }
    }
}