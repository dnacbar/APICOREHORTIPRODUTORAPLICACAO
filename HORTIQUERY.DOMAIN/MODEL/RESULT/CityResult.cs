using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class CityResult : ICityResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int IdState { get; set; }
    }
}
