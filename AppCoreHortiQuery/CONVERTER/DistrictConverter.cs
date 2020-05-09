using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTERS
{
    public static class DistrictConverter
    {
        public static HashSet<DistrictResult> ToHashSetDistrictResult(this IEnumerable<District> listDistrict)
        {
            var consultDistrictResult = new HashSet<DistrictResult>();

            foreach (var x in listDistrict)
            {
                consultDistrictResult.Add(new DistrictResult
                {
                    IdDistrict = x.IdDistrict,
                    DsDistrict = x.DsDistrict
                });
            }

            return consultDistrictResult;
        }

        public static DistrictResult ToDistrictResult(this District district)
        {
            return new DistrictResult
            {
                IdDistrict = district.IdDistrict,
                DsDistrict = district.DsDistrict
            };
        }
    }
}
