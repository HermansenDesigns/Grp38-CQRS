using System.Collections.Generic;
using CQRS.Domain;

namespace CQRS.Command
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
            _userRepo.Save();
        }

        public void Handle(JoinGroupCommand command)
        {
            var user = _userRepo.Find(command.UserId);
            var group = _groupRepo.Find(command.GroupId);
            if (user == null || group == null) return;

            if(group.Members == null)
                group.Members = new List<User>();
            else if (group.Members.Contains(user))
                return;
            group.Members.Add(user);
            _groupRepo.Save();

        }

        public void Handle(AddUserCommand command)
        {
            var user = new User {Age = command.Age, Name = command.Name};
            _userRepo.Add(user);
            _userRepo.Save();
        }
        public void Handle(AddGroupCommand command)
        {
            var group = new Group { Name = command.Name };
            _groupRepo.Add(group);
            _groupRepo.Save();
        }
    }
}
