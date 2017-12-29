using SIENN.Domain.DTO.Category;
using SIENN.Domain.Entities;

namespace SIENN.Services.Abstraction
{
    public interface ICategoryService : IDataService<Category>
    {
        void Update(UpdateCategoryDto dto);
    }
}