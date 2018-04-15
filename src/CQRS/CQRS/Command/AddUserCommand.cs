using System;
using System.ComponentModel.DataAnnotations;

namespace CQRS.Command
{
    public class AddUserCommand : Command
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        [Key]
        public long UserId { get; set; }
        public AddUserCommand(int version, DateTime age, string name) : base(version)
        {
            Age = age;
            Name = name;
        }
    }
}
