using Aircraft.API.Request;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }

        [HttpPost]
        public IActionResult Post(UserRequest request)
        {
            return Ok();
        }
    }
}