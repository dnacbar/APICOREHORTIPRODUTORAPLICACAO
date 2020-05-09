using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultCityApp
    {
        Task<ConsultCityResult> GetCityById(ConsultCitySignature signature);
        Task<IEnumerable<ConsultCityResult>> GetFullListOfCities();
        Task<IEnumerable<ConsultCityResult>> GetListOfCities(ConsultCitySignature signature);
        
    }
}
