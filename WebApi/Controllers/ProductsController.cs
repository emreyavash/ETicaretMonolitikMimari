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

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return Ok(result);
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
    }
}
