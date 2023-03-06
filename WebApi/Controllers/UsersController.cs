using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private  IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAll() {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetUser")]
        public IActionResult Get(int id) { 
            var result = _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            return Ok(result.Message);
        }
        [HttpGet("UserEmail")]
        public IActionResult GetUserEmail(string email) {
            var result = _userService.GetByMail(email);
            return Ok(result);
        }

        [HttpGet("GetUserClaimByEmail")]
        public IActionResult GetUserClaimByEmail(string email)
        {
            var result = _userService.GetUserByMail(email);
            return Ok(result);
        }

    }
}
