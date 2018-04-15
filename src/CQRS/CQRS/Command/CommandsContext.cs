using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Command
{
    public class CommandsContext : DbContext
    {
        public CommandsContext()
        {
        }

        public CommandsContext(DbContextOptions<CommandsContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("CommandsTestDB");
            }
        }

   

        public DbSet<AddGroupCommand> AddGroupCommands { get; set; }
        public DbSet<AddUserCommand> AddUserCommands { get; set; }
        public DbSet<JoinGroupCommand> JoinGroupCommands { get; set; }
        public DbSet<RenameUserCommand> RenameUserCommands { get; set; }
    }
}
