//using FluentValidation;
using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using System;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.SERVICE
{
    public class ProductDomainService : IProductDomainService
    {
        
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }

        public async Task ProductServiceCreate(Product product)
        {
            await _productRepository.CreateProduct(product);
        }

        public async Task ProductServiceDelete(Product product)
        {
            //if (product.IdProduct == Guid.Empty)
            //    throw new ValidationException("PRODUCT NOT EXISTS!");

            await _productRepository.DeleteProduct(product);
        }

        public async Task ProductServiceUpdate(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}