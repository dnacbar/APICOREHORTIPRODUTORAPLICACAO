using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class UnitExtension
    {
        public static IEnumerable<IUnitResult> GetListOfUnitResult(this IEnumerable<Unit> signature)
        {
            var result = new List<IUnitResult>();

            foreach (var item in signature)
                result.Add(new UnitResult(item));

            return result;
        }
    }
}