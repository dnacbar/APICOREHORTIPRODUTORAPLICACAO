using HORTICROSSCUTTINGCORE.EXTENSION;
using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using HORTICOMMAND.DOMAIN.MODEL;
using FluentValidation;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.DOMAIN;

namespace SERVICECOREHORTICOMMAND.SERVICE
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly CreateProductDomainServiceValidation _createProductDomainServiceValidation;
        private readonly UpdateProductDomainServiceValidation _updateProductDomainServiceValidation;

        private readonly IProductRepository _productRepository;

        public ProductDomainService(CreateProductDomainServiceValidation createProductDomainServiceValidation,
                                    UpdateProductDomainServiceValidation updateProductDomainServiceValidation,
                                    IProductRepository productRepository)
        {
            _createProductDomainServiceValidation = createProductDomainServiceValidation;
            _updateProductDomainServiceValidation = updateProductDomainServiceValidation;
            _productRepository = productRepository;
            
        }

        public async Task ProductServiceCreate(Product product)
        {
            _createProductDomainServiceValidation.ValidateHorti(product);

            await _productRepository.CreateProduct(product);
        }

        public async Task ProductServiceDelete(Product product)
        {
            if (product.IdProduct == Guid.Empty)
                throw new ValidationException("PRODUCT NOT EXISTS!");

            await _productRepository.DeleteProduct(product);
        }

        public async Task ProductServiceUpdate(Product product)
        {
            _updateProductDomainServiceValidation.ValidateHorti(product);

            await _productRepository.UpdateProduct(product);
        }
    }
}