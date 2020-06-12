
using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTICOMMAND.Controllers
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
        public async Task<IActionResult> CreateClient([FromBody] ClientCommandSignature signature)
        {
            await _clientCommandApp.CreateClient(signature);
            return Created(string.Empty, null);
        }

        [HttpDelete(nameof(DeleteClient))]
        public async Task<IActionResult> DeleteClient([FromBody] ClientCommandSignature signature)
        {
            await _clientCommandApp.DeleteClient(signature);
            return NoContent();
        }

        [HttpPut(nameof(UpdateClient))]
        public async Task<IActionResult> UpdateClient([FromBody] ClientCommandSignature signature)
        {
            await _clientCommandApp.UpdateClient(signature);
            return NoContent();
        }
    }
}