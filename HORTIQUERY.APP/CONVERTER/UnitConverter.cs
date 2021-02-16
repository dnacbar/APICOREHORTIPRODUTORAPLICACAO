using HORTIQUERY.DOMAIN.MODEL.RESULT;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;

namespace APPCOREHORTIQUERY.CONVERTER
{
    public static class UnitConverter
    {
        public static HashSet<UnitResult> ToHashSetUnitResult(this IEnumerable<Unit> lstUnit)
        {
            var result = new HashSet<UnitResult>();
            foreach (var item in lstUnit)
            {
                result.Add(new UnitResult
                {
                    DsAbreviation = item.DsAbreviation,
                    DsUnit = item.DsUnit,
                    IdUnit = item.IdUnit
                });
            }

            return result;
        }

        public static UnitResult ToUnitResult(this Unit unit)
        {
            return new UnitResult
            {
                DsAbreviation = unit.DsAbreviation,
                DsUnit = unit.DsUnit,
                IdUnit = unit.IdUnit
            };
        }
    }
}
