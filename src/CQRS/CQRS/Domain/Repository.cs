using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domain
{
    public class Repository<TEntity> where TEntity : class 
    {
        private UserGroupContext _context;

        public Repository(UserGroupContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable(); 
        }

        public TEntity Find(long id)
        {
            return _context.Find<TEntity>(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity); 
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity); 
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified; 
        }

        public virtual void Save(TEntity entity, int expectedversion)
        {
            _context.SaveChanges(); 
        }
    }
}
