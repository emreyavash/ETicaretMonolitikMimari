using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavbarsController : ControllerBase
    {
        private INavbarService _navbarService;

        public NavbarsController(INavbarService navbarService)
        {
            _navbarService = navbarService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result  = _navbarService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _navbarService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult Add(Navbar navbar)
        {
            var result = _navbarService.Add(navbar);
            if (result.Success) { 
            return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Navbar navbar)
        {
            var result = _navbarService.Delete(navbar);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Update")]
        public IActionResult Update(Navbar navbar)
        {
            var result = _navbarService.Update(navbar);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
