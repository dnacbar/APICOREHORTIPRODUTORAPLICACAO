using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTIQUERY.EXTENSION;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ProducerController : ControllerBase
    {
        private readonly IProducerQueryApp _producerQueryApp;
        public ProducerController(IProducerQueryApp producerQueryApp)
        {
            _producerQueryApp = producerQueryApp;
        }

        [HttpPost(nameof(GetProducerByIdOrEmail))]
        public async Task<IActionResult> GetProducerByIdOrEmail([FromBody] ProducerQuerySignature signature)
        {
            return Ok((await _producerQueryApp.GetProducerByIdOrName(signature)).Serialize());
        }

        [HttpGet(nameof(GetFullListOfProducers))]
        public async Task<IActionResult> GetFullListOfProducers()
        {
            return Ok((await _producerQueryApp.GetFullListOfProducers()).Serialize());
        }

        [HttpPost(nameof(GetListOfProducers))]
        public async Task<IActionResult> GetListOfProducers([FromBody] ProducerQuerySignature signature)
        {
            return Ok((await _producerQueryApp.GetListOfProducers(signature)).Serialize());
        }
    }
}
