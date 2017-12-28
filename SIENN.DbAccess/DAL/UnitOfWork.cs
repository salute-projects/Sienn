using System;
using System.Threading.Tasks;
using SIENN.DbAccess.Abstraction;
using SIENN.Domain.Entities;

namespace SIENN.DbAccess.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SiennDbContext _context;

        public UnitOfWork(SiennDbContext context)
        {
            _context = context;
        }

        private GenericRepository<Product> _products;
        public GenericRepository<Product> Products => 
            _products ?? (_products = new GenericRepository<Product>(_context));

        private GenericRepository<Category> _categories;
        public GenericRepository<Category> Categories => 
            _categories ?? (_categories = new GenericRepository<Category>(_context));

        private GenericRepository<ProductType> _productTypes;

        public GenericRepository<ProductType> ProductTypes =>
            _productTypes ?? (_productTypes = new GenericRepository<ProductType>(_context));

        private GenericRepository<Unit> _units;
        public GenericRepository<Unit> Units => 
            _units ?? (_units = new GenericRepository<Unit>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
