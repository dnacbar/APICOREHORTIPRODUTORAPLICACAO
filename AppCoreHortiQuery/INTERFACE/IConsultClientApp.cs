using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultClientApp
    {
        Task<IEnumerable<UserClientResult>> GetListOfClients();
        Task<IEnumerable<UserClientResult>> GetListOfClientsByName(ConsultClientSignature signature);
        Task<UserResult> GetClient(ConsultCitySignature signature);
    }
}
