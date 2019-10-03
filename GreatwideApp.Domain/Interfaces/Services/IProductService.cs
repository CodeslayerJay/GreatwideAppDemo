using System.Collections.Generic;
using GreatwideApp.Domain.Entities;

namespace GreatwideApp.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void DeleteProduct(int productId);
        Product GetProduct(int productId);
        
        IEnumerable<Product> GetProducts(int size = 100);
        void SaveProduct(Product product);
    }
}