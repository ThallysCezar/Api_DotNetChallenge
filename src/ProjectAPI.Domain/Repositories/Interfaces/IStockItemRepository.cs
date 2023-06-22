using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Domain.Repositories.Interfaces
{
    public interface IStockItemRepository
    {
        Task<StockItem> CreateAsync(StockItem stockItem);
        Task<List<StockItem>> GetAllAsync();
        Task<StockItem> GetByIdAsync(int id);
        Task<StockItem> UpdateAsync(StockItem stockItem);
        Task DeleteAsync(StockItem stockItem);
        Task AddProductToStockAsync(int productId, int storeId, int quantity);
        Task<List<StockItem>> GetByProductAndStoreAsync(int productId, int storeId);
        Task RemoveProductFromStockAsync(int productId, int storeId, int quantity);
    }
}
