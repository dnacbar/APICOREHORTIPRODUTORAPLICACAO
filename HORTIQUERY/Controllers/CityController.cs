using HORTI.CORE.CROSSCUTTING.ENCRYPTING;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class CityController : ControllerBase
    {
        private readonly ICityQueryApp _cityQueryApp;
        public CityController(ICityQueryApp cityQueryApp)
        {
            _cityQueryApp = cityQueryApp;
        }

        [HttpPost(nameof(GetCityByIdOrName))]
        public async Task<IActionResult> GetCityByIdOrName([FromBody] CityQuerySignature signature)
        {
            return Ok(await _cityQueryApp.GetCityByIdOrName(signature));
        }

        [HttpGet(nameof(GetFullListOfCities))]
        public async Task<IActionResult> GetFullListOfCities()
        {
            return Ok(await _cityQueryApp.GetFullListOfCities());
        }

        [HttpPost(nameof(GetListOfCities))]
        public async Task<IActionResult> GetListOfCities([FromBody] CityQuerySignature signature)
        {
            return Ok(await _cityQueryApp.GetListOfCities(signature));
        }
    }
}
