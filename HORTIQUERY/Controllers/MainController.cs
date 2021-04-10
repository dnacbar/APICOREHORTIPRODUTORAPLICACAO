using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HORTIQUERY.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
