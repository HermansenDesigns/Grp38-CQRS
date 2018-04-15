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

        public void AddItem(TEntity entity)
        {
            var latest = GetLatest();
            var expectedVersion = 0;
            if(latest != null)
                expectedVersion = GetLatest().Version + 1;
            if(entity.Version != expectedVersion)
                throw new ArgumentException();
            _set.Add(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> where)
        {
            return _set.Where(@where);
        }
    }
}
