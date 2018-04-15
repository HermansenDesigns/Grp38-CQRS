using System;

namespace CQRS.Command
{
    public class AddUserCommand : Command
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public AddUserCommand(int version, DateTime age, string name) : base(version)
        {
            Age = age;
            Name = name;
        }
    }
}
