using System.Linq;
using SIENN.Domain.DTO.Product;
using SIENN.Domain.Entities;

namespace SIENN.Domain.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToEntity(this AddProductDto dto)
        {
            return new Product
            {
                Code = dto.Code,
                DeliveryDate = dto.DeliveryDate,
                Description = dto.Description,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price
            };
        }

        public static ProductDetailsDto ToDto(this Product product)
        {
            return new ProductDetailsDto
            {
                Code = product.Code,
                Description = product.Description,
                Created = product.Created,
                DeliveryDate = product.DeliveryDate,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
                Type = product.Type.ToSummary(),
                Unit = product.Unit.ToSummary(),
                Updated = product.Updated,
                Id = product.Id,
                Categories = product.Categories.Select(t => t.Category.ToSummary())
            };
        }
    }
}
