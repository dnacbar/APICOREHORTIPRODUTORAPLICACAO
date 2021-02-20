using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IClientRepository
    {
        Task<Client> ClientByIdOrEmail(IClientQuerySignature signature);
        Task<IEnumerable<Client>> FullListOfClients();
        Task<IEnumerable<Client>> ListOfClients(IClientQuerySignature signature);
    }
}
