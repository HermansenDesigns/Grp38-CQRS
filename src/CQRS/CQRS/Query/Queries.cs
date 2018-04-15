using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Query
{
    public class Queries
    {
        private readonly UserGroupContext _context;

        public Queries(UserGroupContext context)
        {
            _context = context;
        }

        public ICollection<GroupsView> GetAllGroups()
        {
            return _context.Groups.Select(@group => new GroupsView(@group.Id, @group.Name)).ToList();
        }
        public GroupDisplay GetGroupById(long Id)
        {
            var group = _context.Find<Group>(Id);
            return new GroupDisplay(@group.Id, group.Members.Select(@members => new Tuple<string, long>(@members.Name,@members.Id)).ToList());
        }
        public UserDisplay GetUserById(long Id)
        {
            var user = _context.Find<User>(Id);
            return new UserDisplay(user.Id,user.Name,user.Age);

        }
    }
}
