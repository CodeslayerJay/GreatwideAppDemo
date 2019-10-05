using GreatwideApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatwideApp.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GreatwideApp.Domain.Interfaces;
using GreatwideApp.Domain.Filters;

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
                .Where(x => x.ProductId > 0)
                .Where(x => x.ListPrice > 0)
                .Where(x => x.ProductModelId > 0)
                .Include(x => x.ProductModel)
                .Skip(skip)
                .Take(size).OrderByDescending(x => x.ProductId).ToList();
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

        public IEnumerable<ProductModel> GetAllProductModels()
        {
            return _dbContext.ProductModel.Where(x => x.ProductModelId > 0)
                .OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate, ProductFilter filter = null)
        {
            if (filter == null)
                filter = new ProductFilter {
                    Skip = 0,
                    Size = 50,
                    IncludeProductModel = true,
                    IncludeProductReviews = true };

            return Query(filter, predicate).ToList();
        }

        private IQueryable<Product> Query(ProductFilter filter, Expression<Func<Product, bool>> predicate = null)
        {

            var query = _dbContext.Product.Where(x => x.ProductId > 0)
                                          .Where(x => x.ListPrice > 0);

            if (predicate != null)
                query = query.Where(predicate);

            if (filter.IncludeProductModel)
                query = query.Include(x => x.ProductModel);

            //if (filter.IncludeProductReviews)
            //    query = query.Include(x => x.ProductReviews);

            query = query.Skip(filter.Skip).Take(filter.Size).OrderBy(x => x.ProductId);
            
            return query;
        }
    }
}
