using HORTIQUERY.DOMAIN.INTERFACES.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ProducerController : ControllerBase
    {
        private readonly IProducerQueryApp _consultProducerApp;
        public ProducerController(IProducerQueryApp consultProducerApp)
        {
            _consultProducerApp = consultProducerApp;
        }

        [HttpPost(nameof(GetProducerByIdOrEmail))]
        public async Task<IActionResult> GetProducerByIdOrEmail([FromBody] ConsultProducerSignature signature)
        {
            return Ok(await _consultProducerApp.GetProducerByIdOrEmail(signature));
        }

        [HttpGet(nameof(GetFullListOfProducers))]
        public async Task<IActionResult> GetFullListOfProducers()
        {
            return Ok(await _consultProducerApp.GetFullListOfProducers());
        }

        [HttpPost(nameof(GetListOfProducers))]
        public async Task<IActionResult> GetListOfProducers([FromBody] ConsultProducerSignature signature)
        {
            return Ok(await _consultProducerApp.GetListOfProducers(signature));
        }
    }
}
