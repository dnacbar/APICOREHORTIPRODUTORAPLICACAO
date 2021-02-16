using HORTIQUERY.DOMAIN.INTERFACES.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ClientController : ControllerBase
    {
        private readonly IClientQueryApp _consultClientApp;
        public ClientController(IClientQueryApp consultClientApp)
        {
            _consultClientApp = consultClientApp;
        }

        [HttpPost(nameof(GetClientByIdOrEmail))]
        public async Task<IActionResult> GetClientByIdOrEmail([FromBody] ConsultClientSignature signature)
        {
            return Ok(await _consultClientApp.GetClientByIdOrEmail(signature));
        }

        [HttpGet(nameof(GetFullListOfClients))]
        public async Task<IActionResult> GetFullListOfClients()
        {
            return Ok(await _consultClientApp.GetFullListOfClients());
        }

        [HttpPost(nameof(GetListOfClients))]
        public async Task<IActionResult> GetListOfClients([FromBody] ConsultClientSignature signature)
        {
            return Ok(await _consultClientApp.GetListOfClients(signature));
        }
    }
}
