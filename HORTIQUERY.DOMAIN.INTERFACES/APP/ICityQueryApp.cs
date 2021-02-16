using HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface ICityQueryApp
    {
        Task<ICityResult> GetCityById(ConsultCitySignature signature);
        Task<IEnumerable<ICityResult>> GetFullListOfCities();
        Task<IEnumerable<ICityResult>> GetListOfCities(ConsultCitySignature signature);

    }
}
