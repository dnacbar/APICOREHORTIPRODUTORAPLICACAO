namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultUnitSignature : IBaseQuantitySignature
    {
        int IdUnit { get; set; }
        string DsUnit { get; set; }
    }
}
