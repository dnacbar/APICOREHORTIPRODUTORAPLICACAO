using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IProductCommandApp
    {
        Task CreateProduct(IProductCommandSignature signature);
        Task DeleteProduct(IProductCommandSignature signature);
        Task UpdateProduct(IProductCommandSignature signature);
    }
}
