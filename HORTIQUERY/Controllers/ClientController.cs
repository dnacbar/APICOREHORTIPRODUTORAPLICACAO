using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ClientController : ControllerBase
    {
        private readonly IClientQueryApp _clientQueryApp;
        public ClientController(IClientQueryApp clientQueryApp)
        {
            _clientQueryApp = clientQueryApp;
        }

        [HttpPost(nameof(GetClientByIdOrName))]
        public async Task<IActionResult> GetClientByIdOrName([FromBody] ClientQuerySignature signature)
        {
            return Ok((await _clientQueryApp.GetClientByIdOrName(signature)).Serialize());
        }

        [HttpGet(nameof(GetFullListOfClients))]
        public async Task<IActionResult> GetFullListOfClients()
        {
            return Ok((await _clientQueryApp.GetFullListOfClients()).Serialize());
        }

        [HttpPost(nameof(GetListOfClients))]
        public async Task<IActionResult> GetListOfClients([FromBody] ClientQuerySignature signature)
        {
            return Ok((await _clientQueryApp.GetListOfClients(signature)).Serialize());
        }
    }
}
