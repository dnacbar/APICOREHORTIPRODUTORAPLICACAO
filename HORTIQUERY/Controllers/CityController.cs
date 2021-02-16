using HORTIQUERY.DOMAIN.INTERFACES.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class CityController : ControllerBase
    {
        private readonly ICityQueryApp _consultCityApp;
        public CityController(ICityQueryApp consultCityApp)
        {
            _consultCityApp = consultCityApp;
        }

        [HttpPost(nameof(GetCityById))]
        public async Task<IActionResult> GetCityById([FromBody] ConsultCitySignature signature)
        {
            return Ok(await _consultCityApp.GetCityById(signature));
        }

        [HttpGet(nameof(GetFullListOfCities))]
        public async Task<IActionResult> GetFullListOfCities()
        {
            return Ok(await _consultCityApp.GetFullListOfCities());
        }

        [HttpPost(nameof(GetListOfCities))]
        public async Task<IActionResult> GetListOfCities([FromBody] ConsultCitySignature signature)
        {
            return Ok(await _consultCityApp.GetListOfCities(signature));
        }
    }
}
