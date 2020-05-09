using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("producer/[controller]")]
    [ApiController]
    public sealed class UserAccessController : ControllerBase
    {
        private readonly IUserAccessApp _userAccessApp;
        public UserAccessController(IUserAccessApp userAccessApp)
        {
            _userAccessApp = userAccessApp;
        }

        [HttpPost(nameof(ValidateUserAccessClient))]
        public async Task<IActionResult> ValidateUserAccessClient([FromBody]UserAccessSignature signature)
        {
            return Ok(await _userAccessApp.ValidateUserAccessClient(signature));
        }

        [HttpPost(nameof(ValidateUserAccessProducer))]
        public async Task<IActionResult> ValidateUserAccessProducer([FromBody]UserAccessSignature signature)
        {
            return Ok(await _userAccessApp.ValidateUserAccessProducer(signature));
        }
    }
}