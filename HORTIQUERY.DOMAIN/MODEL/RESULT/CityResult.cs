using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class CityResult : ICityResult
    {
        public CityResult() { }

        public CityResult(City city)
        {
            if (city is null)
                return;

            Id = city.IdCity;
            City = city.DsCity;
            IdState = city.IdState;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public int IdState { get; set; }
    }
}
