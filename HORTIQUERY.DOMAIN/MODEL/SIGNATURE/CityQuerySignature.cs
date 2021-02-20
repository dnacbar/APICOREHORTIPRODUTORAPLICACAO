using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class CityQuerySignature : _BaseQuantitySignature, ICityQuerySignature
    {
        public int? Id { get; set; }
        public string City { get; set; }
        public int? IdState { get; set; }
    }
}
