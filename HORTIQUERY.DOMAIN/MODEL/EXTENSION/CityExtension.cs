using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class CityExtension
    {
        public static IEnumerable<ICityResult> GetListOfCityResult(this IEnumerable<City> signature)
        {
            var result = new List<ICityResult>();

            foreach (var item in signature)
                result.Add(new CityResult(item));

            return result;
        }
    }
}
