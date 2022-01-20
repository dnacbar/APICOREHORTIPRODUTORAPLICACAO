namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface ICityQuerySignature : IBaseQuantitySignature, ISignature
    {
        string City { get; set; }
        int? Id { get; set; }
        int? IdState { get; set; }
    }
}
