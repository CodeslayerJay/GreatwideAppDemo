using System.Threading.Tasks;
using GreatwideApp.Domain.Interfaces.Repositories;

namespace GreatwideApp.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; set; }

        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}