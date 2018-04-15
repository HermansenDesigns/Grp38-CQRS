using System;

namespace CQRS.Command
{
    public class Command : ICommand
    {
        public Command(int version)
        {
            Id = Guid.NewGuid();
            Version = version;
        }

        public Guid Id { get; private set; }
        public int Version { get; private set; }
    }
}
