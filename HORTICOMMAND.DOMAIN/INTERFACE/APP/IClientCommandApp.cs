using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IClientCommandApp
    {
        Task CreateClient(IClientCommandSignature signature);
        Task UpdateClient(IClientCommandSignature signature);
    }
}
