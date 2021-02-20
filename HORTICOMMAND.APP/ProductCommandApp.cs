using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL.EXTENSION;
using HORTICOMMAND.VALIDATION.APPLICATION;
using System.Threading.Tasks;

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

            await _productDomainService.ProductServiceCreate(signature.GetProduct());
        }

        public async Task DeleteProduct(IProductCommandSignature signature)
        {
            _deleteProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceDelete(signature.GetProduct());
        }

        public async Task UpdateProduct(IProductCommandSignature signature)
        {
            _updateProductSignatureValidation.ValidateHorti(signature);

            await _productDomainService.ProductServiceUpdate(signature.GetProduct());
        }
    }
}
