using System;
using SIENN.DbAccess.Abstraction;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.DTO.Category;
using SIENN.Domain.Entities;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public class CategoryService : DataService<Category, ICategoryRepository>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out ICategoryRepository repository)
        {
            repository = UnitOfWork.Categories;
        }

        public void Update(UpdateCategoryDto dto)
        {
            var category = GetById(dto.Id);
            if (category == null)
                throw new Exception("Unit not found");
            category.Code = dto.Code;
            category.Description = dto.Description;
            base.Update(category);
        }
    }
}
