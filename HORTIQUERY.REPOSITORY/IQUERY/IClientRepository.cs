using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IClientRepository
    {
        Task<IClient> ClientByIdOrEmail(ConsultClientSignature signature);
        Task<IEnumerable<IClient>> FullListOfClients();
        Task<IEnumerable<IClient>> ListOfClients(ConsultClientSignature signature);
    }
}
