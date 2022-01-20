using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IClientRepository
    {
        Task<Client> ClientByIdOrName(IClientQuerySignature signature);
        Task<List<Client>> FullListOfClients();
        Task<List<Client>> ListOfClients(IClientQuerySignature signature);
    }
}
