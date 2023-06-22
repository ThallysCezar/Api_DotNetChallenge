using ProjectAPI.Application.DTOs;

namespace ProjectAPI.Application.Services.Interfaces
{
    public interface IStockItemService
    {
        Task<ResultService<StockItemDTO>> CreateAsync(StockItemDTO stockItemDTO);
        Task<ResultService<List<StockItemDTO>>> GetAllAsync();
        Task<ResultService<StockItemDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(StockItemDTO stockItemDTO);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<List<StockItemDTO>>> GetByProductAndStoreAsync(int productId, int storeId);
        Task<ResultService> AddProductToStockAsync(int productId, int storeId, int quantity);
        Task<ResultService> RemoveProductFromStockAsync(int productId, int storeId, int quantity);
    }
}
