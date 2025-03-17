using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;
using ECommerce.Infrastructure.EfCore;

namespace ECommerce.Infrastructure
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;

        public EfCoreRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            T entity =_context.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public List<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
