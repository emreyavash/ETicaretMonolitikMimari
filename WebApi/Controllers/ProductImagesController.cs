using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetByImageId")]
        public IActionResult GetByImageId(int id) 
        { 
            var result = _productImageService.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpGet("GetImageByProductId")]
        public IActionResult GetImageByProductId(int id) 
        {
            var result = _productImageService.GetImageByProductId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPost("AddImage")]
        public IActionResult AddImage([FromForm(Name = "Image")] IFormFile file,[FromForm]ProductImage productImage)
        {
            var result = _productImageService.Add(file,productImage);
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("DeleteImage")]
        public IActionResult DeleteImage(ProductImage productImage)
        {
            var result = _productImageService.Delete(productImage); 
            if(result.Success) { 
            return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UpdateImage")]
        public IActionResult UpdateImage([FromForm(Name = "Image")] IFormFile file, [FromForm] ProductImage productImage)
        {
            var result = _productImageService.Update(file,productImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
