using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS
{
    public class CQRSContext : DbContext
    {
        public CQRSContext()
        {
        }

        public CQRSContext(DbContextOptions<CQRSContext> options) : base(options)
        {

        }
    }
}
