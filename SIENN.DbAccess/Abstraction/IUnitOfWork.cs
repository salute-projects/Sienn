using System.Threading.Tasks;
using SIENN.DbAccess.DAL;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.Abstraction
{
    public interface IUnitOfWork
    {
        GenericRepository<Product> Products { get; }
        GenericRepository<Category> Categories { get; }
        GenericRepository<ProductType> ProductTypes { get; }
        GenericRepository<Unit> Units { get; }

        void Save();
        Task<int> SaveAsync();
    }
}