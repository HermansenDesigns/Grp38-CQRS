using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
