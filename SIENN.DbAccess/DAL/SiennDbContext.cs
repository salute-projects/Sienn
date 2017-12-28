using Microsoft.EntityFrameworkCore;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.DAL
{
    public class SiennDbContext : DbContext
    {
        public SiennDbContext() {}

        public SiennDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
