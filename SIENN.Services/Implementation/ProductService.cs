using Microsoft.Extensions.Logging;
using SIENN.DbAccess.Abstraction;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}
