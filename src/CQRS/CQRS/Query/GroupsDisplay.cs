using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Command;

namespace CQRS.Query
{
    public class GroupsDisplay
    {
        public JoinGroupCommand LatestJoinGroupCommand { get; set; }
        public GroupsDisplay(long id, string name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        public long LocalId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual List<UserDisplay> Members { get; set; }
    }
}
