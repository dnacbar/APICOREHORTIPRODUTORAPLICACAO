using DomainCoreHortiCommand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCoreHortiQuery.IQUERIES
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListOfCities();
        Task<IEnumerable<City>> ListOfCities(int idPage, int idSize);
        Task<City> GetCityByCode(int idCity);
        Task<City> GetCityByName(string strCity);
        void Dispose();
    }
}
