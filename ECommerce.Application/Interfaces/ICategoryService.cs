using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);

        CategoryDto Get(Expression<Func<Category, bool>> predicate);
        List<CategoryDto> GetAll(Expression<Func<Category, bool>>? predicate, bool AsNoTracking);
        void Add(CreateCategoryDto createDto);
        void Update(UpdateCategoryDto updateDto);
        void Remove(int id);

    }
}
