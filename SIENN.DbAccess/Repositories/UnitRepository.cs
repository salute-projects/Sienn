using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DbContext context) : base(context)
        {
        }
    }
}
