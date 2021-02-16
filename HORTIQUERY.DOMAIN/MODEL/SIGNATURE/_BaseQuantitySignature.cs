using HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public abstract class _BaseQuantitySignature : IBaseQuantitySignature
    {
        public int Page { get; set; } = 0;
        public int Quantity { get; set; } = 20;
    }
}
