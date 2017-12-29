using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
