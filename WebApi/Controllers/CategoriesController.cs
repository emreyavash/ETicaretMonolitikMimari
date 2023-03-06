using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
           var result = _categoryService.Add(category);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Category category) 
        {
            var result = _categoryService.Update(category);
            return Ok(result);
        }

        [HttpGet("GetCategory")]
        public IActionResult Get(int id)
        {
            var result = _categoryService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
