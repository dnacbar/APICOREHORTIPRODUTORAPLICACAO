using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListOfCities();
        Task<IEnumerable<City>> ListOfCitiesByQuantity(ConsultByQuantitySignature signature);
        Task<IEnumerable<City>> ListOfCitiesByName(ConsultCitySignature signature);
        Task<City> CityById(ConsultCitySignature signature);
        Task<IEnumerable<City>> ListOfCitiesByState(ConsultCitySignature signature);
    }
}
