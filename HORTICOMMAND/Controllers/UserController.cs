using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.MODEL.SIGNATURE;
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
        public async Task<IActionResult> CreateUser([FromBody] UserCommandSignature signature)
        {
            await _userCommandApp.CreateUser(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(InactiveUser))]
        public async Task<IActionResult> InactiveUser([FromBody] UserCommandSignature signature)
        {
            await _userCommandApp.InactiveUser(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromBody] UserCommandSignature signature)
        {
            await _userCommandApp.UpdateUser(signature);
            return NoContent();
        }
    }
}