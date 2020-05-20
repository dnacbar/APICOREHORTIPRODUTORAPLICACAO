using APPDTOCOREHORTIQUERY.RESULT;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTER
{
    public static class DistrictConverter
    {
        public static HashSet<DistrictResult> ToHashSetDistrictResult(this IEnumerable<District> listDistrict)
        {
            var result = new HashSet<DistrictResult>();

            foreach (var x in listDistrict)
            {
                result.Add(new DistrictResult
                {
                    IdDistrict = x.IdDistrict,
                    DsDistrict = x.DsDistrict
                });
            }

            return result;
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
