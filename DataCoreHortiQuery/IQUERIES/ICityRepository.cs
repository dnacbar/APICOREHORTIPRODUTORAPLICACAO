using DataCoreHortiQuery.CONTEXT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCoreHortiQuery.IQUERIES
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListOfCities();
        Task<City> GetCityByCode(int idCity);
        void Dispose();
    }
}
