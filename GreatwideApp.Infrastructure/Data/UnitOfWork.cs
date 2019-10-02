using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreatwideApp.Infrastructure.Data
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        // Repositories (In Memory)



        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
