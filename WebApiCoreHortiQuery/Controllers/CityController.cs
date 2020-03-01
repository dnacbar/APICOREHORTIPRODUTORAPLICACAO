using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("producer/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IConsultCityApp _consultCityApp;
        public CityController(IConsultCityApp consultCityApp)
        {
            _consultCityApp = consultCityApp;
        }

        [HttpGet(nameof(GetListOfCities))]
        public async Task<IActionResult> GetListOfCities()
        {
            return Ok(await _consultCityApp.GetListOfCities());
        }

        [HttpPost(nameof(GetListOfCitiesByQuantity))]
        public async Task<IActionResult> GetListOfCitiesByQuantity([FromBody] ConsultByQuantitySignature signature)
        {
            return Ok(await _consultCityApp.GetListOfCitiesByQuantity(signature));
        }

        [HttpPost(nameof(GetListOfCitiesByName))]
        public async Task<IActionResult> GetListOfCitiesByName([FromBody] ConsultCitySignature signature)
        {
            return Ok(await _consultCityApp.GetListOfCitiesByName(signature));
        }

        [HttpPost(nameof(GetCityById))]
        public async Task<IActionResult> GetCityById([FromBody] ConsultCitySignature signature)
        {
            return Ok(await _consultCityApp.GetCityById(signature));
        }

        [HttpPost(nameof(GetListOfCitiesByState))]
        public async Task<IActionResult> GetListOfCitiesByState(ConsultCitySignature signature)
        {
            return Ok(await _consultCityApp.GetListOfCitiesByState(signature));
        }
    }
}
