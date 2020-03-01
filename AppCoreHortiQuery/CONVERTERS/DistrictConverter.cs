using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class DistrictConverter
    {
        public static HashSet<ConsultDistrictResult> ToHashSetDistrictResult(this IEnumerable<District> listDistrict)
        {
            var consultDistrictResult = new HashSet<ConsultDistrictResult>();

            foreach (var x in listDistrict)
            {
                consultDistrictResult.Add(new ConsultDistrictResult
                {
                    IdDistrict = x.IdDistrict,
                    DsDistrict = x.DsDistrict
                });
            }

            return consultDistrictResult;
        }

        public static ConsultDistrictResult ToDistrictResult(this District district)
        {
            return new ConsultDistrictResult
            {
                IdDistrict = district.IdDistrict,
                DsDistrict = district.DsDistrict
            };
        }
    }
}
