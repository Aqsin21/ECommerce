using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.Infrastructure.EfCore
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;

        public EfCoreRepository(AppDbContext context)
        {
            _context = context;

        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            T entity = _context.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>>? predicate, bool AsNoTracking = false)
        {
            IQueryable<T> quareyable = _context.Set<T>();
            if (predicate != null)
                quareyable = quareyable.Where(predicate);

            if (!AsNoTracking)
                quareyable = quareyable.AsNoTracking();
            return quareyable.ToList();
        }

        public virtual T GetById(int id)
        {
            T entity = _context.Set<T>().Find(id);

            return entity;
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
