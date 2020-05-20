using APPCOREHORTIQUERY.CONVERTER;
using APPCOREHORTIQUERY.IAPP;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using CROSSCUTTINGCOREHORTI.ENUM;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.APP
{
    public sealed class CityQueryApp : ICityQueryApp
    {
        private readonly ICityRepository _cityRepository;

        public CityQueryApp(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<CityResult> GetCityById(ConsultCitySignature signature)
        {
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.CityById(signature)).ToCityResult();
        }

        public async Task<IEnumerable<CityResult>> GetFullListOfCities()
        {
            return (await _cityRepository.FullListOfCities()).ToHashSetCityResult();
        }

        public async Task<IEnumerable<CityResult>> GetListOfCities(ConsultCitySignature signature)
        {
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.ListOfCities(signature)).ToHashSetCityResult();
        }
    }
}
