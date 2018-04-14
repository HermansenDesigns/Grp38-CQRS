using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS
{
    public abstract class Repository<TEntity> where TEntity : class 
    {
        private CQRSContext _context;

        public Repository(CQRSContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable(); 
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
