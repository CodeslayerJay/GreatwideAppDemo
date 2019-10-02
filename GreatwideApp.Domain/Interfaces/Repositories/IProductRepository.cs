using System.Collections.Generic;
using System.Threading.Tasks;
using GreatwideApp.Domain.Entities;

namespace GreatwideApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        Task<IEnumerable<Product>> GetAllAsync(int size = 100);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId);
        void Remove(int id);
    }
}