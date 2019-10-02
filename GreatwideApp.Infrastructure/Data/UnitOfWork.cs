using GreatwideApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreatwideApp.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        // Repositories (In Memory)
        public IProductRepository Products { get; set; }


        public UnitOfWork(ApplicationDbContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
