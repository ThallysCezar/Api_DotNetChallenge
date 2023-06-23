using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int? pageNumber, int? pageQuantity)
        {
            var result = await _storeService.GetAsync(pageNumber ?? 0, pageQuantity ?? int.MaxValue);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByAsync(int id)
        {
            var result = await _storeService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] StoreDTO storeDto)
        {
            var result = await _storeService.CreateAsync(storeDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] StoreDTO storeDto)
        {
            var result = await _storeService.UpdateAsync(storeDto);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _storeService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
