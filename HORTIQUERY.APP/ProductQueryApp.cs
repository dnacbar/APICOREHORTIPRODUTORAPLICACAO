using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public class ProductQueryApp : IProductQueryApp
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryApp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<IProductResult>> GetFullListOfProducts()
        {
            return (await _productRepository.FullListOfProducts()).GetListOfProductResult();
        }

        public async Task<IEnumerable<IProductResult>> GetListOfProducts(IProductQuerySignature signature)
        {
            return (await _productRepository.ListOfProducts(signature)).GetListOfProductResult();
        }

        public async Task<IProductResult> GetProductByIdOrName(IProductQuerySignature signature)
        {
            return (await _productRepository.ProductByIdOrName(signature)).GetProductResult();
        }
    }
}
