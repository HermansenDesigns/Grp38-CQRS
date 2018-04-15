using Microsoft.EntityFrameworkCore;

namespace CQRS.Domain
{
    public class UserGroupContext : DbContext
    {
        public UserGroupContext()
        {
        }

        public UserGroupContext(DbContextOptions<UserGroupContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("TestDB");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
