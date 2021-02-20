using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class DistrictExtension
    {
        public static IDistrictResult GetDistrictResult(this District signature)
        {
            return new DistrictResult
            {
                Id = signature.IdDistrict,
                District = signature.DsDistrict
            };
        }

        public static IEnumerable<IDistrictResult> GetListOfDistrictResult(this IEnumerable<District> signature)
        {
            var result = new List<IDistrictResult>();
            foreach (var item in signature)
            {
                result.Add(new DistrictResult
                {
                    Id = item.IdDistrict,
                    District = item.DsDistrict
                });
            }
            return result;
        }
    }
}