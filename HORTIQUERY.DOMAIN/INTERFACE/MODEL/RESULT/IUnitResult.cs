namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IUnitResult : IResult
    {
        int Id { get; set; }
        string Unit { get; set; }
        string Abreviation { get; set; }
    }
}
