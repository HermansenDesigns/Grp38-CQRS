using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class RenameUserCommand : Command
    {
        public readonly string NewName;
        public readonly string OldName;
        public readonly long UserId;

        public RenameUserCommand(string newName, int version, string oldName, long userId) : base(version)
        {
            OldName = oldName;
            UserId = userId;
            NewName = newName;
        }
    }
}
