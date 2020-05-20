using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTICOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitCommandApp _unitCommandApp;

        public UnitController(IUnitCommandApp unitCommandApp)
        {
            _unitCommandApp = unitCommandApp;
        }

        [HttpPost(nameof(CreateUnit))]
        public async Task<IActionResult> CreateUnit([FromBody]UnitCommandSignature signature)
        {
            await _unitCommandApp.CreateUnit(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(DeleteUnit))]
        public async Task<IActionResult> DeleteUnit([FromBody] UnitCommandSignature signature)
        {
            await _unitCommandApp.DeleteUnit(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateUnit))]
        public async Task<IActionResult> UpdateUnit([FromBody]UnitCommandSignature signature)
        {
            await _unitCommandApp.UpdateUnit(signature);
            return NoContent();
        }
    }
}