using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.DTOs.Validations;
using ProjectAPI.Application.Services.Interfaces;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;

namespace ProjectAPI.Application.Services
{
    public class StockItemService : IStockItemService
    {
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IMapper _mapper;

        public StockItemService(IStockItemRepository stockItemRepository, IMapper mapper)
        {
            _stockItemRepository = stockItemRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<StockItemDTO>> CreateAsync(StockItemDTO stockItemDTO)
        {
            if (stockItemDTO == null)
                return ResultService.Fail<StockItemDTO>("Object need be informate");

            var result = new StockItemDTOValidator().Validate(stockItemDTO);
            if (!result.IsValid)
                return ResultService.RequestError<StockItemDTO>("Problem of the validate!", result);

            var stockItem = _mapper.Map<StockItem>(stockItemDTO);
            var data = await _stockItemRepository.CreateAsync(stockItem);
            return ResultService.Ok(_mapper.Map<StockItemDTO>(data));
        }

        public async Task<ResultService<List<StockItemDTO>>> GetAllAsync(int pageNumber = 0, int pageQuantity = int.MaxValue)
        {
            var stockItems = await _stockItemRepository.GetAllAsync(pageNumber, pageQuantity);
            return ResultService.Ok(_mapper.Map<List<StockItemDTO>>(stockItems));
        }

        public async Task<ResultService<StockItemDTO>> GetByIdAsync(int id)
        {
            var stockItem = await _stockItemRepository.GetByIdAsync(id);
            if (stockItem == null)
                return ResultService.Fail<StockItemDTO>("stockItem not found!");
            return ResultService.Ok(_mapper.Map<StockItemDTO>(stockItem));
        }

        public async Task<ResultService> UpdateAsync(StockItemDTO stockItemDTO)
        {
            if (stockItemDTO == null)
                return ResultService.Fail("Product need be informate");

            var validation = new StockItemDTOValidator().Validate(stockItemDTO);

            if (!validation.IsValid)
                return ResultService.RequestError("Problem with the field validation", validation);

            var stockItem = await _stockItemRepository.GetByIdAsync(stockItemDTO.Id);
            if (stockItem == null)
                return ResultService.Fail("Product not found!");

            stockItem = _mapper.Map<StockItemDTO, StockItem>(stockItemDTO, stockItem);
            await _stockItemRepository.UpdateAsync(stockItem);
            return ResultService.Ok("StockItem updated!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var stockItem = await _stockItemRepository.GetByIdAsync(id);
            if (stockItem == null)
                return ResultService.Fail("Product is not found!");

            await _stockItemRepository.DeleteAsync(stockItem);
            return ResultService.Ok($"Product to id: {id} was Deleted!");
        }

        //falta implementar
        public Task<ResultService> AddProductToStockAsync(int productId, int storeId, int quantity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<List<StockItemDTO>>> GetByProductAndStoreAsync(int productId, int storeId)
        {
            var stockItems = await _stockItemRepository.GetByProductAndStoreAsync(productId, storeId);
            var stockItemsDTO = _mapper.Map<List<StockItemDTO>>(stockItems);
            return ResultService.Ok(stockItemsDTO);
        }

        //falta implementar
        public Task<ResultService> RemoveProductFromStockAsync(int productId, int storeId, int quantity)
        {
            throw new NotImplementedException();
        }       
    }
}
