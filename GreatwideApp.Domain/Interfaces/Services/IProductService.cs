using System.Collections.Generic;
using GreatwideApp.Domain.Entities;

namespace GreatwideApp.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void DeleteProduct(int productId);
        Product GetProduct(int productId);
        
        IEnumerable<Product> GetProducts(int skip = 0, int size = 30);
        void SaveProduct(Product product);
        IEnumerable<ProductModel> GetAllProductModels();
        Product GetByProductNumber(string productNumber);
        Product GetByProductName(string productName);
        int GetProductCount();

        IEnumerable<ProductReview> GetProductReviews(int productId, int size = 10);
    }
}