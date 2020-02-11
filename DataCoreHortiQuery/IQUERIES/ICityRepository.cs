using APPDTOCOREHORTIQUERY.SIGNATURE;
using DomainCoreHortiCommand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListOfCities();
        Task<IEnumerable<City>> ListOfCitiesByQuantity(ConsultByQuantitySignature signature);
        Task<IEnumerable<City>> ListOfCitiesByName(ConsultCityByIdNameSignature signature);
        Task<City> CityById(ConsultCityByIdNameSignature signature);
        Task<IEnumerable<City>> ListOfCitiesByState(ConsultCityByStateSignature signature);
    }
}
