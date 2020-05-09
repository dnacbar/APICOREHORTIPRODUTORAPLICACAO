using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("producer/[controller]")]
    [ApiController]
    public sealed class DistrictController : ControllerBase
    {
        private readonly IConsultDistrictApp _consultDistrictApp;

        public DistrictController(IConsultDistrictApp consultDistrictApp)
        {
            _consultDistrictApp = consultDistrictApp;
        }

        [HttpGet(nameof(GetListOfDistricts))]
        public async Task<IActionResult> GetListOfDistricts()
        {
            return Ok(await _consultDistrictApp.GetListOfDistricts());
        }

        [HttpPost(nameof(GetListOfDistrictsByQuantity))]
        public async Task<IActionResult> GetListOfDistrictsByQuantity(ConsultByQuantitySignature signature)
        {
            return Ok(await _consultDistrictApp.GetListOfDistrictsByQuantity(signature));
        }

        [HttpPost(nameof(GetDistrictById))]
        public async Task<IActionResult> GetDistrictById(ConsultDistrictSignature signature)
        {
            return Ok(await _consultDistrictApp.GetDistrictById(signature));
        }

        [HttpPost(nameof(GetListOfDistrictsByName))]
        public async Task<IActionResult> GetListOfDistrictsByName(ConsultDistrictSignature signature)
        {
            return Ok(await _consultDistrictApp.GetListOfDistrictsByName(signature));
        }
    }
}
