using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Domain.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> CreateAsync(Store store);
        Task<List<Store>> GetAllASync(int pageNumber, int pageQuantity);
        Task<Store> UpdateAsync(Store store);
        Task DeleteAsync(Store store);
        Task<Store> GetByIdAsync(int id);
    }
}
