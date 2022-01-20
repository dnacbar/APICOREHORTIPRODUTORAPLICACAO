using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IUnitQuerySignature : IBaseQuantitySignature
    {
        int? Id { get; set; }
        string DsUnit { get; set; }
    }
}
