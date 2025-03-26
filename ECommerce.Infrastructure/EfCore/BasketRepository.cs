
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.Infrastructure.EfCore
{
    public class BasketRepository :EfCoreRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) :base(context) 
        { 
        }
    }
}
