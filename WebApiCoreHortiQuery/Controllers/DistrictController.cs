using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("horti/[controller]")]
    [ApiController]
    public sealed class DistrictController : ControllerBase
    {
        private readonly IConsultDistrictApp _consultDistrictApp;

        public DistrictController(IConsultDistrictApp consultDistrictApp)
        {
            _consultDistrictApp = consultDistrictApp;
        }

        [HttpPost(nameof(GetDistrictByIdOrName))]
        public async Task<IActionResult> GetDistrictByIdOrName(ConsultDistrictSignature signature)
        {
            return Ok(await _consultDistrictApp.GetDistrictByIdOrName(signature));
        }

        [HttpGet(nameof(GetFullListOfDistricts))]
        public async Task<IActionResult> GetFullListOfDistricts()
        {
            return Ok(await _consultDistrictApp.GetFullListOfDistricts());
        }

        [HttpPost(nameof(GetListOfDistricts))]
        public async Task<IActionResult> GetListOfDistricts(ConsultDistrictSignature signature)
        {
            return Ok(await _consultDistrictApp.GetListOfDistricts(signature));
        }
    }
}
