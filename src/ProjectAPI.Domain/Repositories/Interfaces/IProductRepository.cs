using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllASync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
