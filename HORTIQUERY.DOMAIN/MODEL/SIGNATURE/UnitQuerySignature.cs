using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class UnitQuerySignature : _BaseQuantitySignature, IUnitQuerySignature
    {
        public int? Id { get; set; }
        public string DsUnit { get; set; }
    }
}
