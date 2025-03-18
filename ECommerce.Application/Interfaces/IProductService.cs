using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        ProductDto GetById(int id);

        ProductDto Get(Expression<Func<Product, bool>> predicate);
        List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool AsNoTracking);
        void Add(CreateProductDto createDto);
        void Update(UpdateProductDto updateDto);
        void Remove(int id);
    }
}
