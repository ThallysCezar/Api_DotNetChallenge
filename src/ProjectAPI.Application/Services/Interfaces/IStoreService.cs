using ProjectAPI.Application.DTOs;

namespace ProjectAPI.Application.Services.Interfaces
{
    public interface IStoreService
    {
        Task<ResultService<StoreDTO>> CreateAsync(StoreDTO storeDTO);
        Task<ResultService<ICollection<StoreDTO>>> GetAsync(int pageNumber, int pageQuantity);
        Task<ResultService<StoreDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(StoreDTO storeDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
