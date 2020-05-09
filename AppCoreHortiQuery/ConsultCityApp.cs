using APPCOREHORTIQUERY.CONVERTERS;
using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.ENUM;
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
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.CityById(signature)).ToCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetFullListOfCities()
        {
            return (await _cityRepository.FullListOfCities()).ToHashSetCityResult();
        }

        public async Task<IEnumerable<ConsultCityResult>> GetListOfCities(ConsultCitySignature signature)
        {
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.ListOfCities(signature)).ToHashSetCityResult();
        }
    }
}
