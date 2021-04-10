using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.EXCEPTION;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
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
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.CityByIdOrName(signature)).GetCityResult();
        }

        public async Task<IEnumerable<ICityResult>> GetFullListOfCities()
        {
            return (await _cityRepository.FullListOfCities()).GetListOfCityResult();
        }

        public async Task<IEnumerable<ICityResult>> GetListOfCities(ICityQuerySignature signature)
        {
            if (signature is null)
                throw new FluentValidation.ValidationException(((int)EnumException.City).ToString());

            return (await _cityRepository.ListOfCities(signature)).GetListOfCityResult();
        }
    }
}
