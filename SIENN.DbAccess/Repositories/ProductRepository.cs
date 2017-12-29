using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
