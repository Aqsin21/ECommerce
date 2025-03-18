using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderItemService
    {
        OrderItemDto GetById(int id);

        OrderItemDto Get(Expression<Func<OrderItem, bool>> predicate);
        List<OrderItemDto> GetAll(Expression<Func<OrderItem, bool>>? predicate, bool AsNoTracking);
        void Add(CreateOrderItemDto createDto);
        void Update(UpdateOrderItemDto updateDto);
        void Remove(int id);

    }
}
