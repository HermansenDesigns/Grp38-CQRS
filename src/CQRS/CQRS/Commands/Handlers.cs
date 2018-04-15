using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain;

namespace CQRS.Commands
{
    public class Handlers
    {
        private readonly Repository<User> _userRepo;
        private readonly Repository<Group> _groupRepo;

        public Handlers(UserGroupContext context)
        {
            _userRepo = new Repository<User>(context);
            _groupRepo = new Repository<Group>(context);
        }

        public void Handle(RenameUserCommand command)
        {
            var user = _userRepo.Find(command.UserId);
            if (user == null || user.Name != command.OldName) return;
            user.Name = command.NewName;
            _userRepo.Save(user,0);
        }

        public void Handle(JoinGroupCommand command)
        {
            var user = _userRepo.Find(command.UserId);
            var group = _groupRepo.Find(command.GroupId);
            if (user == null || group == null || group.Members.Contains(user)) return;
            group.Members.Add(user);
            _groupRepo.Save(group,0);

        }
    }
}
