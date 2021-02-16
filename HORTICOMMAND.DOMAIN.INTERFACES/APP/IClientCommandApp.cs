using HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.APP
{
    public interface IClientCommandApp
    {
        Task CreateClient(IClientCommandSignature signature);
        Task UpdateClient(IClientCommandSignature signature);
    }
}
