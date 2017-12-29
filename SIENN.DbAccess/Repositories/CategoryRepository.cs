using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
