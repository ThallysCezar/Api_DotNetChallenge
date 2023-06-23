using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.Services.Interfaces;

namespace ProjectAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(int? pageNumber, int? pageQuantity)
        {
            var result = await _productService.GetAsync(pageNumber ?? 0, pageQuantity ?? int.MaxValue);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDTO productDto)
        {
            var result = await _productService.CreateAsync(productDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDto)
        {
            var result = await _productService.UpdateAsync(productDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
