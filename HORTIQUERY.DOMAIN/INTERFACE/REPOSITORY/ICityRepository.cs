using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface ICityRepository
    {
        Task<City> CityByIdOrName(ICityQuerySignature signature);
        Task<List<City>> FullListOfCities();
        Task<List<City>> ListOfCities(ICityQuerySignature signature);
    }
}
