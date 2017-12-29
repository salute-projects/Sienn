using SIENN.Domain.DTO.Category;
using SIENN.Domain.Entities;

namespace SIENN.Domain.Extensions
{
    public static class CategoryExtensions
    {
        public static Category ToEntity(this AddCategoryDto dto)
        {
            return new Category
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static CategorySummaryDto ToSummary(this Category category)
        {
            return new CategorySummaryDto
            {
                Description = category.Description,
                Code = category.Code,
                Id = category.Id
            };
        }
    }
}
