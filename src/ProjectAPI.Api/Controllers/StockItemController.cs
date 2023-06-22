using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.Services;
using ProjectAPI.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult> GetAsync()
        {
            var result = await _stockItemService.GetAllAsync();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByAsync(int id)
        {
            var result = await _stockItemService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] StockItemDTO stockItemDTO)
        {
            var result = await _stockItemService.CreateAsync(stockItemDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] StockItemDTO stockItemDTO)
        {
            var result = await _stockItemService.UpdateAsync(stockItemDTO);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

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
