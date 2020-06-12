using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTICOMMAND.Controllers
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

        [HttpDelete(nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser([FromBody] UserCommandSignature signature)
        {
            await _userCommandApp.DeleteUser(signature);
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