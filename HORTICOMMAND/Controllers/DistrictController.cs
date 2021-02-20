using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTICOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictCommandApp _districtCommandApp;

        public DistrictController(IDistrictCommandApp districtCommandApp)
        {
            _districtCommandApp = districtCommandApp;
        }

        [HttpPost(nameof(CreateDistrict))]
        public async Task<IActionResult> CreateDistrict([FromBody] DistrictCommandSignature signature)
        {
            await _districtCommandApp.CreateDistrict(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(DeleteDistrict))]
        public async Task<IActionResult> DeleteDistrict([FromBody] DistrictCommandSignature signature)
        {
            await _districtCommandApp.DeleteDistrict(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateDistrict))]
        public async Task<IActionResult> UpdateDistrict([FromBody] DistrictCommandSignature signature)
        {
            await _districtCommandApp.UpdateDistrict(signature);
            return NoContent();
        }
    }
}