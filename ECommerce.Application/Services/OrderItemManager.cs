using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class OrderItem : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItem(IOrderItemRepository repository)
        {
            _repository = repository;
        }


        public void Add(CreateOrderItemDto createDto)
        {
            throw new NotImplementedException();


        }

        public OrderItemDto Get(Expression<Func<Domain.Entities.OrderItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<OrderItemDto> GetAll(Expression<Func<Domain.Entities.OrderItem, bool>>? predicate, bool AsNoTracking)
        {
            throw new NotImplementedException();
        }

        public OrderItemDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateOrderItemDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
