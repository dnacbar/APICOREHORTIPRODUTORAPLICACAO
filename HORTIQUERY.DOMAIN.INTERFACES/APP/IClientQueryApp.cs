using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IClientQueryApp
    {
        Task<IUserResult> GetClientByIdOrEmail(ConsultClientSignature signature);
        Task<IEnumerable<ClientResult>> GetFullListOfClients();
        Task<IEnumerable<ClientResult>> GetListOfClients(ConsultClientSignature signature);
    }
}
