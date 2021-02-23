using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ProductController : ControllerBase
    {
        private readonly IProductQueryApp _productQueryApp;
        public ProductController(IProductQueryApp productQueryApp)
        {
            _productQueryApp = productQueryApp;
        }

        [HttpPost(nameof(GetProductByIdOrName))]
        public async Task<IActionResult> GetProductByIdOrName([FromBody] ProductQuerySignature signature)
        {
            return Ok(await _productQueryApp.GetProductByIdOrName(signature));
        }

        [HttpGet(nameof(GetFullListOfProducts))]
        public async Task<IActionResult> GetFullListOfProducts()
        {
            return Ok(await _productQueryApp.GetFullListOfProducts());
        }

        [HttpPost(nameof(GetListOfProducts))]
        public async Task<IActionResult> GetListOfProducts([FromBody] ProductQuerySignature signature)
        {
            return Ok(await _productQueryApp.GetListOfProducts(signature));
        }
    }
}
