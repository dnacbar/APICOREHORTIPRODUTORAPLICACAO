using HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.APP
{
    public interface IProductCommandApp
    {
        Task CreateProduct(IProductCommandSignature signature);
        Task DeleteProduct(IProductCommandSignature signature);
        Task UpdateProduct(IProductCommandSignature signature);
    }
}
