

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CQRS.Command
{
    public class AddGroupCommand : Command
    {
        public string Name { get; set; }
        [Key]
        public long GroupId { get; set; }
        public AddGroupCommand(int version, string name) : base(version)
        {
            Name = name;
        }


    }
}
