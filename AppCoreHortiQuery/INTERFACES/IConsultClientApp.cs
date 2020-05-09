using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultClientApp
    {
        Task<IEnumerable<UserClientInformationResult>> GetListOfClients();
        Task<IEnumerable<UserClientInformationResult>> GetListOfClientsByName(ConsultClientSignature signature);
        Task<UserInformationResult> GetClient(ConsultCitySignature signature);
    }
}
