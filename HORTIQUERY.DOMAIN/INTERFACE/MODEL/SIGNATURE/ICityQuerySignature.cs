namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface ICityQuerySignature : IBaseQuantitySignature
    {
        string City { get; set; }
        int? Id { get; set; }
        int? IdState { get; set; }
    }
}
