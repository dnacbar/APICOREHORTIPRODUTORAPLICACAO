using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class CityExtension
    {
        public static ICityResult GetCityResult(this City signature)
        {
            return new CityResult
            {
                Id = signature.IdCity,
                City = signature.DsCity,
                IdState = signature.IdState
            };
        }

        public static IEnumerable<ICityResult> GetListOfCityResult(this IEnumerable<City> signature)
        {
            var result = new List<ICityResult>(); 
            foreach (var item in signature)
            {
                result.Add(new CityResult
                {
                    Id = item.IdCity,
                    City = item.DsCity,
                    IdState = item.IdState
                });
            }

            return result;
        }
    }
}
