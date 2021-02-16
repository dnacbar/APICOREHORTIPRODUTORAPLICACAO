using HORTICOMMAND.APP.CONVERTER;
using HORTICOMMAND.DOMAIN.INTERFACES.APP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICROSSCUTTINGCORE.EXTENSION;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.APPLICATION;

namespace HORTICOMMAND.APP
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

        public async Task CreateProduct(IProductCommandSignature signature)
        {
            _createProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceCreate(signature.ToCreateProductDomain());
        }

        public async Task DeleteProduct(IProductCommandSignature signature)
        {
            _deleteProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceDelete(signature.ToDeleteProductDomain());
        }

        public async Task UpdateProduct(IProductCommandSignature signature)
        {
            _updateProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceUpdate(signature.ToUpdateProductDomain());
        }
    }
}
