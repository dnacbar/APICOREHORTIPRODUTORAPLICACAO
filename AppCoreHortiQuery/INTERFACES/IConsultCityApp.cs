using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultCityApp
    {
        Task<IEnumerable<ConsultCityResult>> GetListOfCities();
        Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByQuantity(ConsultByQuantitySignature signature);
        Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByName(ConsultCitySignature signature);
        Task<ConsultCityResult> GetCityById(ConsultCitySignature signature);
        Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByState(ConsultCitySignature signature);
    }
}
