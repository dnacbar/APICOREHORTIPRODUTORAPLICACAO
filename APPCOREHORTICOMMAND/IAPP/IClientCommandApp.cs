using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IClientCommandApp
    {
        Task CreateClient(ClientCommandSignature signature);
        Task DeleteClient(ClientCommandSignature signature);
        Task UpdateClient(ClientCommandSignature signature);
    }
}
