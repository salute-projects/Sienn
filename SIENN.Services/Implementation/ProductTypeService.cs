using System;
using SIENN.DbAccess.Abstraction;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.DTO.ProductType;
using SIENN.Domain.Entities;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public class ProductTypeService : DataService<ProductType, IProductTypeRepository>, IProductTypeService
    {
        public ProductTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out IProductTypeRepository repository)
        {
            repository = UnitOfWork.ProductTypes;
        }

        public void Update(UpdateProductTypeDto dto)
        {
            var productType = GetById(dto.Id);
            if (productType == null)
                throw new Exception("Unit not found");
            productType.Code = dto.Code;
            productType.Description = dto.Description;
            base.Update(productType);
        }
    }
}
