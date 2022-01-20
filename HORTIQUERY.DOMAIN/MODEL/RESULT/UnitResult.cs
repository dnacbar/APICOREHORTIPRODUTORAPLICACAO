using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class UnitResult : IUnitResult
    {
        public UnitResult(Unit unit)
        {
            Id = unit.IdUnit;
            Unit = unit.DsUnit;
            Abreviation = unit.DsAbreviation;
        }

        public int Id { get; set; }
        public string Unit { get; set; }
        public string Abreviation { get; set; }
    }
}
