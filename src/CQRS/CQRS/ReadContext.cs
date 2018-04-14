using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS
{
    public class ReadContext : DbContext
    {
        public ReadContext()
        {
        }

        public ReadContext(DbContextOptions<ReadContext> options) : base(options)
        {

        }

        public DbSet<ProductQuick> Products { get; set; }
    }
}
