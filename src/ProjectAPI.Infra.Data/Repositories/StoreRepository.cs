using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;
using ProjectAPI.Infra.Data.Context;

namespace ProjectAPI.Infra.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Store> CreateAsync(Store store)
        {
            _context.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task DeleteAsync(Store store)
        {
            _context.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Store>> GetAllASync(int pageNumber, int pageQuantity)
        {
            if (pageNumber < 0)
                pageNumber = 0;

            if (pageQuantity <= 0)
                pageQuantity = int.MaxValue;

            return await _context.Stores
                    .Skip(pageNumber * pageQuantity)
                    .Take(pageQuantity)
                    .ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Store> UpdateAsync(Store store)
        {
            _context.Update(store);
            await _context.SaveChangesAsync();
            return store;
        }
    }
}
