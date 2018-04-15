using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    internal sealed class Events
    {
        public delegate void groupAdded(AddGroupCommand command);
        public delegate void userAdded(AddUserCommand command);
        public delegate void userJoinedGroup(JoinGroupCommand command);
        public delegate void userRenamed(RenameUserCommand command);

        public event groupAdded GroupAdded;
        public event userAdded UserAdded;
        public event userJoinedGroup UserJoinedGroup;
        public event userRenamed UserRenamed;

        public static Events CommandEvents = new Events();

        public void OnGroupAdded(AddGroupCommand command)
        {
            GroupAdded?.Invoke(command);
        }

        public void OnUserAdded(AddUserCommand command)
        {
            UserAdded?.Invoke(command);
        }

        public void OnUserJoinedGroup(JoinGroupCommand command)
        {
            UserJoinedGroup?.Invoke(command);
        }

        public void OnUserRenamed(RenameUserCommand command)
        {
            UserRenamed?.Invoke(command);
        }
    }
    
}
