using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IProductCommandApp
    {
        Task CreateProduct(ProductCommandSignature signature);
        Task DeleteProduct(ProductCommandSignature signature);
        Task UpdateProduct(ProductCommandSignature signature);
    }
}
