using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;
using ProjectAPI.Infra.Data.Context;

namespace ProjectAPI.Infra.Data.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        private readonly AppDbContext _context;

        public StockItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StockItem> CreateAsync(StockItem stockItem)
        {
            _context.Add(stockItem);
            await _context.SaveChangesAsync();
            return stockItem;
        }

        public async Task<StockItem> GetByIdAsync(int id)
        {
            return await _context.StockItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<StockItem>> GetAllAsync()
        {
            return await _context.StockItems.ToListAsync();
        }

        public async Task<StockItem> UpdateAsync(StockItem stockItem)
        {
            _context.Update(stockItem);
            await _context.SaveChangesAsync();
            return stockItem;
        }

        public async Task DeleteAsync(StockItem stockItem)
        {
            _context.Remove(stockItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StockItem>> GetByProductAndStoreAsync(int productId, int storeId)
        {
            return await _context.StockItems
                .Where(s => s.ProductId == productId && s.StoreId == storeId)
                .ToListAsync();
        }

        public async Task AddProductToStockAsync(int productId, int storeId, int quantity)
        {
            var stockItem = await _context.StockItems
            .SingleOrDefaultAsync(s => s.ProductId == productId && s.StoreId == storeId);

            if (stockItem != null)
            {
                stockItem.Quantity += quantity;
            }
            else
            {
                stockItem = new StockItem
                {
                    ProductId = productId,
                    StoreId = storeId,
                    Quantity = quantity
                };
                _context.StockItems.Add(stockItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductFromStockAsync(int productId, int storeId, int quantity)
        {
            var stockItem = await _context.StockItems
                .SingleOrDefaultAsync(s => s.ProductId == productId && s.StoreId == storeId);

            if (stockItem != null)
            {
                if (stockItem.Quantity >= quantity)
                {
                    stockItem.Quantity -= quantity;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Insufficient quantity in stock.");
                }
            }
            else
            {
                throw new Exception("Product not found in stock.");
            }

        }
    }
}