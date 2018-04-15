using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Command;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Query
{
    public class Queries : ICommandAppliable<AddGroupCommand>, ICommandAppliable<AddUserCommand>, ICommandAppliable<JoinGroupCommand>, ICommandAppliable<RenameUserCommand>
    {
        private readonly QueryContext _context;
        public AddGroupCommand LatestAddGroupCommand { get; set; }
        public AddUserCommand LatestAddUserCommand { get; set; }
        public JoinGroupCommand LatestJoinGroupCommand { get; set; }
        public RenameUserCommand LatestRenameUserCommand { get; set; }
        public Queries()
        {
            _context = new QueryContext();
            
            // Only communicating over Events
            Events.CommandEvents.GroupAdded += Apply;
            Events.CommandEvents.UserAdded += Apply;
            Events.CommandEvents.UserRenamed += Apply;
            Events.CommandEvents.GroupAdded += Apply;
        }
        public void Apply(AddGroupCommand entity)
        {
            _context.Groups.Add(new Group(entity.GroupId, entity.Name));
            LatestAddGroupCommand = entity;
        }

        public void Apply(AddUserCommand entity)
        {
            _context.UserDisplays.Add(new UserDisplay(entity.UserId, entity.Name, entity.Age));
            LatestAddUserCommand = entity;
        }

        public void Apply(JoinGroupCommand entity)
        {
            var group = _context.Groups.Find(entity.GroupId);
            var user = _context.UserDisplays.Find(entity.UserId);
            if (group == null || user == null)
                return;
            _context.GroupDisplays.Find(entity.GroupId).Members.Add(user);
            LatestJoinGroupCommand = entity;
        }

        public void Apply(RenameUserCommand entity)
        {
            var user = _context.UserDisplays.Find(entity.UserId);
            user.Name = entity.NewName;
            LatestRenameUserCommand = entity;
        }
    }
}
