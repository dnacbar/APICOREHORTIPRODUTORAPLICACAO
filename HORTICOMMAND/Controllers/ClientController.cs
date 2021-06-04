using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTICOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase  
    {
        private readonly IClientCommandApp _clientCommandApp;

        public ClientController(IClientCommandApp clientCommandApp)
        {
            _clientCommandApp = clientCommandApp;
        }

        [HttpPost(nameof(CreateClient))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateClient([FromBody] ClientCommandSignature signature)
        {
            await _clientCommandApp.CreateClient(signature);
            return Created(string.Empty, null);
        }

        [HttpPut(nameof(UpdateClient))]
        [Authorize]
        public async Task<IActionResult> UpdateClient([FromBody] ClientCommandSignature signature)
        {
            await _clientCommandApp.UpdateClient(signature);
            return NoContent();
        }
    }
}