using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class CityConverter
    {
        public static HashSet<CityResult> ToHashSetCityResult(this IEnumerable<City> listCity)
        {
            var consultCityResult = new HashSet<CityResult>();

            foreach (var x in listCity)
            {
                consultCityResult.Add(new CityResult
                {
                    DsCity = x.DsCity,
                    IdCity = x.IdCity,
                    IdState = x.IdState
                });
            }
            return consultCityResult;
        }

        public static CityResult ToCityResult(this City city)
        {
            return new CityResult
            {
                DsCity = city.DsCity,
                IdCity = city.IdCity,
                IdState = city.IdState
            };
        }
    }
}
