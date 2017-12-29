using SIENN.Domain.DTO.ProductType;
using SIENN.Domain.Entities;

namespace SIENN.Domain.Extensions
{
    public static class ProductTypeExtensions
    {
        public static ProductType ToEntity(this AddProductTypeDto dto)
        {
            return new ProductType
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static ProductTypeSummaryDto ToSummary(this ProductType type)
        {
            return new ProductTypeSummaryDto
            {
                Description = type.Description,
                Code = type.Code,
                Id = type.Id
            };
        }
    }
}
