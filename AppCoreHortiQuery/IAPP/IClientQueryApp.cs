using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IClientQueryApp
    {
        Task<UserResult> GetClientByIdOrEmail(ConsultClientSignature signature);
        Task<IEnumerable<ClientResult>> GetFullListOfClients();
        Task<IEnumerable<ClientResult>> GetListOfClients(ConsultClientSignature signature);
    }
}
