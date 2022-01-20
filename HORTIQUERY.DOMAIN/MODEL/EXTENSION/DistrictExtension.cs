using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class DistrictExtension
    {
        public static IEnumerable<IDistrictResult> GetListOfDistrictResult(this IEnumerable<District> signature)
        {
            var result = new List<IDistrictResult>();

            foreach (var item in signature)
                result.Add(new DistrictResult(item));

            return result;
        }
    }
}