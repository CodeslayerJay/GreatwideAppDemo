using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Filters;

namespace GreatwideApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll(int skip = 0, int size = 100);
        
        Product GetById(int id);
        
        IEnumerable<ProductReview> GetProductReviews(int productId, int size = 10);
        void Remove(int id);
        IEnumerable<ProductModel> GetAllProductModels();
        IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate, ProductFilter filter = null);
        int GetCount();
        void AddReview(ProductReview review);
    }
}