using APPCOREHORTICOMMAND.APP.CONVERTER;
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using CROSSCUTTINGCOREHORTI.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using VALIDATIONCOREHORTICOMMAND.APPLICATION;

namespace APPCOREHORTICOMMAND.APP
{
    public class ProductCommandApp : IProductCommandApp
    {
        private readonly CreateProductSignatureValidation _createProductSignatureValidation;
        private readonly DeleteProductSignatureValidation _deleteProductSignatureValidation;
        private readonly UpdateProductSignatureValidation _updateProductSignatureValidation;

        private readonly IProductDomainService _productDomainService;

        public ProductCommandApp(CreateProductSignatureValidation createProductSignatureValidation,
                                 DeleteProductSignatureValidation deleteProductSignatureValidation,
                                 UpdateProductSignatureValidation updateProductSignatureValidation,
                                 IProductDomainService productDomainService)
        {
            _createProductSignatureValidation = createProductSignatureValidation;
            _deleteProductSignatureValidation = deleteProductSignatureValidation;
            _updateProductSignatureValidation = updateProductSignatureValidation;
            _productDomainService = productDomainService;
        }

        public async Task CreateProduct(ProductCommandSignature signature)
        {
            _createProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceCreate(signature.ToCreateProductDomain());
        }

        public async Task DeleteProduct(ProductCommandSignature signature)
        {
            _deleteProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceDelete(signature.ToDeleteProductDomain());
        }

        public async Task UpdateProduct(ProductCommandSignature signature)
        {
            _updateProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceUpdate(signature.ToUpdateProductDomain());
        }
    }
}
