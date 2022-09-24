using Aircraft.API.Request;
using Aircraft.API.Response;
using Aircraft.Application.Interfaces;
using Aircraft.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aircraft.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _service;
        private readonly IAuthService _authService;

        public AuthenticationController(IUserService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        /// <summary>
        /// Inserting user and creating JWT Token
        /// </summary>
        /// <param name="request">UserRequest</param>
        /// <returns>AuthenticationResponse</returns>
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Post(UserRequest request)
        {

            if (request == null || string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Invalid Credentials");

            UserProfile user = await _service.GetByLoginCredentials(request.Login, request.Password);

            string token = _authService.GenerateToken(user);

            return Ok(new AuthenticationResponse(user.Id, token));
        }
    }
}