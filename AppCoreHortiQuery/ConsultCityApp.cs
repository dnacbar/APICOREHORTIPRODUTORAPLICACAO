using APPCOREHORTIQUERY.CONVERTERS;
using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY
{
    public sealed class ConsultCityApp : IConsultCityApp
    {
        private readonly ICityRepository _cityRepository;

        public ConsultCityApp(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ConsultCityResult> GetCityById(ConsultCitySignature signature)
        {
            return (await _cityRepository.CityById(signature)).ToCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetListOfCities()
        {
            return (await _cityRepository.ListOfCities()).ToHashSetCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByName(ConsultCitySignature signature)
        {
            return (await _cityRepository.ListOfCitiesByName(signature)).ToHashSetCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByQuantity(ConsultByQuantitySignature signature)
        {
            return (await _cityRepository.ListOfCitiesByQuantity(signature)).ToHashSetCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetListOfCitiesByState(ConsultCitySignature signature)
        {
            return (await _cityRepository.ListOfCitiesByState(signature)).ToHashSetCityResult();
        }
    }
}
