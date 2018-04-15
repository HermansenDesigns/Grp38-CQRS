using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Query
{
    public class GroupDisplay
    {
        public GroupDisplay(long groupId, List<Tuple<string, long>> members)
        {
            GroupId = groupId;
            Members = members;
        }

        public long GroupId { get; }
        public List<Tuple<string, long>> Members { get; }
    }
}
