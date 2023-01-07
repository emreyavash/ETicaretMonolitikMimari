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

        [HttpPost]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            return Ok(result.Message);
        }

    }
}
