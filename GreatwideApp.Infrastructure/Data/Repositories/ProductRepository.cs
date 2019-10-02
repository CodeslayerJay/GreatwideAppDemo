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

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Product
                    .Include(x => x.ProductModel)
                    .Include(x => x.ProductReview)
                    .SingleOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int size = 100)
        {
            return await _dbContext.Product.Take(size).ToListAsync();
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

        public async Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId)
        {
            return await _dbContext.ProductReview.Include(x => x.Product)
                .Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
