using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Command;

namespace CQRS.Query
{
    public class GroupDisplay
    {
        public GroupDisplay(long groupId, List<UserDisplay> members)
        {
            GroupId = groupId;
            Members = members;
        }
        [Key]
        public long GroupId { get; }
        public List<UserDisplay> Members { get; }

    }
}
