using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private  IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegister)
        {
            var userExist = _authService.UserExists(userForRegister.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerdUser = _authService.Register(userForRegister, userForRegister.Password);
            var result = _authService.CreateAccessToken(registerdUser.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLogin) 
        {
            var userLogin = _authService.Login(userForLogin);
            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }
            var result = _authService.CreateAccessToken(userLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
