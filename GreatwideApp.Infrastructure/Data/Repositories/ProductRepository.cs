using GreatwideApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatwideApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GreatwideApp.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll(int skip = 0, int size = 100)
        {
            return _dbContext.Product
                .Include(x => x.ProductModel)
                .Skip(skip)
                .Take(size).OrderBy(x => x.ModifiedDate).ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Product
                    .Include(x => x.ProductModel)
                    .Include(x => x.ProductReviews)
                    .SingleOrDefault(x => x.ProductId == id);
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
