using System.Collections.Generic;
using System.Threading.Tasks;
using GreatwideApp.Domain.Entities;

namespace GreatwideApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll(int skip = 0, int size = 100);
        
        Product GetById(int id);
        
        IEnumerable<ProductReview> GetProductReviews(int productId);
        void Remove(int id);
    }
}