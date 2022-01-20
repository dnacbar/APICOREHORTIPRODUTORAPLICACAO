using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public sealed class CityQueryApp : ICityQueryApp
    {
        private readonly ICityRepository _cityRepository;

        public CityQueryApp(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ICityResult> GetCityByIdOrName(ICityQuerySignature signature)
        {
            return new CityResult(await _cityRepository.CityByIdOrName(signature));
        }

        public async Task<IEnumerable<ICityResult>> GetFullListOfCities()
        {
            return (await _cityRepository.FullListOfCities()).GetListOfCityResult();
        }

        public async Task<IEnumerable<ICityResult>> GetListOfCities(ICityQuerySignature signature)
        {
            return (await _cityRepository.ListOfCities(signature)).GetListOfCityResult();
        }
    }
}
