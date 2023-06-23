using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.Services.Interfaces;

namespace ProjectAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemService _stockItemService;

        public StockItemController(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(int? pageNumber, int? pageQuantity)
        {
            var result = await _stockItemService.GetAllAsync(pageNumber ?? 0, pageQuantity ?? int.MaxValue);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByAsync(int id)
        {
            var result = await _stockItemService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] StockItemDTO stockItemDTO)
        {
            var result = await _stockItemService.CreateAsync(stockItemDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] StockItemDTO stockItemDTO)
        {
            var result = await _stockItemService.UpdateAsync(stockItemDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _stockItemService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
