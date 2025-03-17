using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;


namespace ECommerce.Infrastructure.EfCore
{
    public class CustomerRepository : EfCoreRepository<User>, IUserRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
