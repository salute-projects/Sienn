using SIENN.Domain.DTO.ProductType;
using SIENN.Domain.Entities;

namespace SIENN.Services.Abstraction
{
    public interface IProductTypeService : IDataService<ProductType>
    {
        void Update(UpdateProductTypeDto dto);
    }
}