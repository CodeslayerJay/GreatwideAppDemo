using GreatwideApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatwideApp.Domain.Interfaces.Repositories;

namespace GreatwideApp.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll(int size = 100)
        {
            return _dbContext.Product.Take(size).ToList();
        }

        // Use EntityFramework + LINQ to Query
        public Product GetById(int id)
        {
            return _dbContext.Product
                    .Include(x => x.ProductModel)
                    .Include(x => x.ProductReview)
                    .SingleOrDefault(x => x.ProductId == id);
        }

        // Use EF with Stored Procedure Example
        public Product SP_GetById(int id)
        {
             var product = _dbContext.Product.FromSql($"spProducts_GetProduct {id} ").FirstOrDefault();
            return product;
        }


        public void Add(Product product)
        {
            if (product != null)
            {
                _dbContext.Product.Add(product);
            }
        }

        public void Remove(int id)
        {
            var product = _dbContext.Product.SingleOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                _dbContext.Product.Remove(product);
            }
        }

        public IEnumerable<ProductReview> GetProductReviews(int productId)
        {
            return _dbContext.ProductReview.Include(x => x.Product)
                .Where(x => x.ProductId == productId).ToList();
        }
    }
}
