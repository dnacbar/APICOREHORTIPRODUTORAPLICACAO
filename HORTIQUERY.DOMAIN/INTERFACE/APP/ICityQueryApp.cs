using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface ICityQueryApp
    {
        Task<ICityResult> GetCityById(ICityQuerySignature signature);
        Task<IEnumerable<ICityResult>> GetFullListOfCities();
        Task<IEnumerable<ICityResult>> GetListOfCities(ICityQuerySignature signature);

    }
}
