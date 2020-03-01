using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IClientRepository
    {
        Task<Client> GetClientByEmail(ConsultClientSignature signature);
    }
}
