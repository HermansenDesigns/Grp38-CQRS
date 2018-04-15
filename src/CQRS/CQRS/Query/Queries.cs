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
        
        
        
        
        public Queries()
        {
            _context = new QueryContext();
            
            // Only communicating over Events
            Events.CommandEvents.GroupAdded += Apply;
            Events.CommandEvents.UserAdded += Apply;
            Events.CommandEvents.UserRenamed += Apply;
            Events.CommandEvents.UserJoinedGroup += Apply;
        }

        #region Repository

        public List<GroupsDisplay> GetAllGroups()
        {
            return _context.Groups.ToList();
        }
        public List<UserDisplay> GetAllUsers()
        {
            return _context.UserDisplays.ToList();
        }


        #endregion



        public void Apply(AddGroupCommand entity)
        {
            _context.Groups.Add(new GroupsDisplay(entity.GroupId, entity.Name));
            _context.SaveChanges();
        }

        public void Apply(AddUserCommand entity)
        {
            _context.UserDisplays.Add(new UserDisplay(entity.UserId, entity.Name, entity.Age));
            _context.SaveChanges();
        }

        public void Apply(JoinGroupCommand entity)
        {
            var group = _context.Groups.Find(entity.GroupId);
            var user = _context.UserDisplays.Find(entity.UserId);
            if (group == null || user == null)
                return;
            if(group.Members == null)
                group.Members = new List<UserDisplay>();
            group.Members.Add(user);
            group.LatestJoinGroupCommand = entity;
            _context.SaveChanges();
        }

        public void Apply(RenameUserCommand entity)
        {
            var user = _context.UserDisplays.Find(entity.UserId);
            user.Name = entity.NewName;
            user.LatestRenameUserCommand = entity;
            _context.SaveChanges();
        }
    }
}
