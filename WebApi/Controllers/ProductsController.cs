using Business.Abstract;
using Business.Constants;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);
            return Ok(result);
        }

        [HttpGet("GetProductDetail")]
        public IActionResult GetProductDetail(int id)
        {
            var result = _productService.GetProductDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            product.CreatedDate = DateTime.UtcNow;
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPost("Update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            return Ok(result);
        }

        [HttpGet("GetProductsByUserId")]
        public IActionResult GetProductsByUserId(int userId)
        {
            var result = _productService.GetAllById(userId);
            return Ok(result);
        }
    }
}
