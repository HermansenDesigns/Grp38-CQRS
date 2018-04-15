using System;

namespace CQRS.Command
{
    public interface ICommand
    {
        Guid Id { get; }
        int Version { get; }
    }
}
