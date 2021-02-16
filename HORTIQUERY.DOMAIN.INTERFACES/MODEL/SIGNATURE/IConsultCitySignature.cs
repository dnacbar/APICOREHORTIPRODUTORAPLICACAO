namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IConsultCitySignature : IBaseQuantitySignature
    {
        string DsCity { get; set; }
        int? IdCity { get; set; }
        int? IdState { get; set; }
    }
}
