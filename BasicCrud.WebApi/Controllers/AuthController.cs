using BasicCrud.Business.Abstract;
using BasicCrud.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto loginUser)
        {
            var userToLogin = _authService.Login(loginUser);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
