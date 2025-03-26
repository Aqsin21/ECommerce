using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;


namespace ECommerce.Application.Interfaces
{
    public interface IBasketService
    {
       

      
        List<BasketDto> GetAll(Expression<Func<Basket, bool>>? predicate, bool AsNoTracking);
       
       
    }
}
