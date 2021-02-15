using APPCOREHORTICOMMAND.IAPP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPICOREHORTICOMMAND.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerCommandApp _producerCommandApp;

        public ProducerController(IProducerCommandApp producerCommandApp)
        {
            _producerCommandApp = producerCommandApp;
        }

        [HttpPut(nameof(UpdateProducer))]
        public async Task<IActionResult> UpdateProducer([FromBody] ProducerCommandSignature signature)
        {
            await _producerCommandApp.UpdateProducer(signature);
            return NoContent();
        }
    }
}