using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class JoinGroupCommand : Command
    {
        public readonly long UserId;
        public readonly long GroupId;

        public JoinGroupCommand(int version, long userId, long groupId) : base(version)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
    
}
