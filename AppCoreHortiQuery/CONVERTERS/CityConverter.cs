using APPDTOCOREHORTIQUERY.RESULT;
using DomainCoreHortiCommand;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class CityConverter
    {
        public static HashSet<ConsultCityResult> ToHashSetCityResult(this IEnumerable<City> listCity)
        {
            var consultCityResult = new HashSet<ConsultCityResult>();

            foreach (var x in listCity)
            {
                consultCityResult.Add(new ConsultCityResult
                {
                    DsCity = x.DsCity,
                    CdCity = x.CdCity,
                    IdState = x.IdState
                });
            }
            return consultCityResult;
        }

        public static ConsultCityResult ToCityResult(this City city)
        {
            return new ConsultCityResult
            {
                DsCity = city.DsCity,
                CdCity = city.CdCity,
                IdState = city.IdState
            };
        }
    }
}
