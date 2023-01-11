using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var result = _sellerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id) { 
            var result = _sellerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AddSeller")]
        public IActionResult Add(Seller seller)
        {
            var result = _sellerService.Add(seller);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("DeleteSeller")]
        public IActionResult Delete(Seller seller)
        {
            var result = _sellerService.Delete(seller);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("UpdateSeller")]
        public IActionResult Update(Seller seller)
        {
            var result = _sellerService.Update(seller);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
