using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface ICityRepository
    {
        Task<ICity> CityById(ConsultCitySignature signature);
        Task<IEnumerable<ICity>> FullListOfCities();
        Task<IEnumerable<ICity>> ListOfCities(ConsultCitySignature signature);
    }
}
