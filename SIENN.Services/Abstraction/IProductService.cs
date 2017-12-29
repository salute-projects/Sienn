using System.Collections.Generic;
using SIENN.Domain.DTO.Product;
using SIENN.Domain.Infrastructure;

namespace SIENN.Services.Abstraction
{
    public interface IProductService
    {
        ProductDetailsDto GetById(int id);
        Page<ProductDetailsDto> GetPage(PagingReqest request);
        Page<ProductDetailsDto> Search(ProductFilterRequest request);
        IEnumerable<ProductDetailsDto> GetAll();
        void Add(AddProductDto dto);
        void Update(UpdateProductDto dto);
        void Delete(int id);
    }
}