using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Command
{
    public class CommandRepository<TEntity> where TEntity : Command
    {
        private DbSet<TEntity> _set;

        public CommandRepository(DbSet<TEntity> set)
        {
            _set = set;
        }

        public TEntity GetLatest()
        {
            var orderedByVersion = _set.OrderBy(item => item.Version);
            return !orderedByVersion.Any() ? null : orderedByVersion.Last();
        }

        public void CheckVersionAndAddItem(Func<TEntity, bool> where, TEntity entity)
        {
            //Create collection with commands matching our entity.
            var collection = Find(where);
            var expectedVersion = 0;
            if (collection.Any())
            {
                expectedVersion = collection.ToList().OrderBy(item => item.Version).Last().Version;
            }
            //Test if version supplied by command matches the latest version +1
            if (entity.Version != (expectedVersion + 1))
                throw new ArgumentException();
            AddItem(entity);
        }

        private void AddItem(TEntity entity)
        {
           _set.Add(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> where)
        {
            return _set.Where(@where);
        }
    }
}
