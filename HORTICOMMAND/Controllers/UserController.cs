using HORTICOMMAND.DOMAIN.INTERFACES.APP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTICOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandApp _userCommandApp;

        public UserController(IUserCommandApp userCommandApp)
        {
            _userCommandApp = userCommandApp;
        }

        [HttpPost(nameof(CreateUser))]
        public async Task<IActionResult> CreateUser([FromBody] IUserCommandSignature signature)
        {
            await _userCommandApp.CreateUser(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(InactiveUser))]
        public async Task<IActionResult> InactiveUser([FromBody] IUserCommandSignature signature)
        {
            await _userCommandApp.InactiveUser(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromBody] IUserCommandSignature signature)
        {
            await _userCommandApp.UpdateUser(signature);
            return NoContent();
        }
    }
}