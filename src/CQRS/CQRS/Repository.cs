using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    class Repository<TEntity>
    {
        private CQRSContext _context;

        public Repository(CQRSContext context)
        {
            _context = context;
        }

        public TEntity Get(Guid id)
        {
            return _context; 
        }

        public void Add(TEntity entity)
        {
            
        }

        public void Delete(TEntity entity)
        {

        }

        public void Edit(TEntity entity)
        {

        }

    }
}
