using FluentValidation;
using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.VALIDATION.DOMAIN;
using System;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
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