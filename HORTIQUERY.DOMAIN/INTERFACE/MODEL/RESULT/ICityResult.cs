namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface ICityResult : IResult
    {
        int Id { get; set; }
        string City { get; set; }
        int IdState { get; set; }
    }
}
