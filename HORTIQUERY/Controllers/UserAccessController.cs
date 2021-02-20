using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class UserAccessController : ControllerBase
    {
        private readonly IUserAccessApp _userAccessApp;
        public UserAccessController(IUserAccessApp userAccessApp)
        {
            _userAccessApp = userAccessApp;
        }

        [HttpPost(nameof(ValidateUserAccessClient))]
        public async Task<IActionResult> ValidateUserAccessClient([FromBody] UserAccessQuerySignature signature)
        {
            return Ok(await _userAccessApp.ValidateUserAccessClient(signature));
        }

        [HttpPost(nameof(ValidateUserAccessProducer))]
        public async Task<IActionResult> ValidateUserAccessProducer([FromBody] UserAccessQuerySignature signature)
        {
            return Ok(await _userAccessApp.ValidateUserAccessProducer(signature));
        }
    }
}