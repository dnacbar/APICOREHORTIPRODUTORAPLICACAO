using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IClientRepository
    {
        Task<Client> ClientByIdOrEmail(ConsultClientSignature signature);
        Task<IEnumerable<Client>> FullListOfClients();
        Task<IEnumerable<Client>> ListOfClients(ConsultClientSignature signature);
    }
}
