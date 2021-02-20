using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class UnitExtension
    {
        public static IUnitResult GetUnitResult(this Unit signature)
        {
            return new UnitResult
            {
                Id = signature.IdUnit,
                Unit = signature.DsUnit,
                Abreviation = signature.DsAbreviation
            };
        }

        public static IEnumerable<IUnitResult> GetListOfUnitResult(this IEnumerable<Unit> signature)
        {
            var result = new List<IUnitResult>();
            foreach (var item in signature)
            {
                result.Add(new UnitResult
                {
                    Id = item.IdUnit,
                    Unit = item.DsUnit,
                    Abreviation = item.DsAbreviation
                });
            }
            return result;
        }
    }
}