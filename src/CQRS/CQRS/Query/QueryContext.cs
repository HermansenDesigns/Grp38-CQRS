using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Query
{
    public class QueryContext : DbContext
    {
        public QueryContext()
        {
        }

        public QueryContext(DbContextOptions<QueryContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("QueryTestDB");
            }
        }

        public DbSet<GroupDisplay> GroupDisplays { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserDisplay> UserDisplays { get; set; }

    }
}
