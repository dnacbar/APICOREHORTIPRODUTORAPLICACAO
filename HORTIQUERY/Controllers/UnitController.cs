using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class UnitController : ControllerBase
    {
        private readonly IUnitQueryApp _unitQueryApp;
        public UnitController(IUnitQueryApp unitQueryApp)
        {
            _unitQueryApp = unitQueryApp;
        }

        [HttpPost(nameof(GetUnitById))]
        public async Task<IActionResult> GetUnitById([FromBody] UnitQuerySignature signature)
        {
            return Ok((await _unitQueryApp.GetUnitByIdOrName(signature)).Serialize());
        }

        [HttpGet(nameof(GetFullListOfUnits))]
        public async Task<IActionResult> GetFullListOfUnits()
        {
            return Ok((await _unitQueryApp.GetFullListOfUnits()).Serialize());
        }

        [HttpPost(nameof(GetListOfUnits))]
        public async Task<IActionResult> GetListOfUnits([FromBody] UnitQuerySignature signature)
        {
            return Ok((await _unitQueryApp.GetListOfUnits(signature)).Serialize());
        }
    }
}
