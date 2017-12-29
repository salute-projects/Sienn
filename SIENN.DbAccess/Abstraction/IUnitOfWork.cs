using System.Threading.Tasks;
using SIENN.DbAccess.Repositories.Abstraction;

namespace SIENN.DbAccess.Abstraction
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IProductTypeRepository ProductTypes { get; }
        IUnitRepository Units { get; }

        void Save();
        Task<int> SaveAsync();
    }
}