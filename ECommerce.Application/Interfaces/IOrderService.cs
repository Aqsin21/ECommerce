using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetById(int id);

        OrderDto Get(Expression<Func<Order, bool>> predicate);
        List<OrderDto> GetAll(Expression<Func<Order, bool>>? predicate, bool AsNoTracking);
        void Add(CreateOrderDto createDto);
        void Update(UpdateOrderDto updateDto);
        void Remove(int id);
    }
}
