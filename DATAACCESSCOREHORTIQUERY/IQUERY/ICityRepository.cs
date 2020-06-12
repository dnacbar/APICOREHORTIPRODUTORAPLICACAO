using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface ICityRepository
    {
        Task<City> CityById(ConsultCitySignature signature);
        Task<IEnumerable<City>> FullListOfCities();
        Task<IEnumerable<City>> ListOfCities(ConsultCitySignature signature);
    }
}
