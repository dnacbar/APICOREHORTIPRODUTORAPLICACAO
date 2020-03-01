using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("producer/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        public UserAccessController()
        {

        }

        [HttpGet(nameof(UserAccess))]
        public async Task<IActionResult> UserAccess()
        { 
            return Ok();
        }
    }
}
