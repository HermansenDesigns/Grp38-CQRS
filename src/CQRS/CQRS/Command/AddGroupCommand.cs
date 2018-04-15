namespace CQRS.Command
{
    public class AddGroupCommand : Command
    {
        public string Name { get; set; }
        public AddGroupCommand(int version, string name) : base(version)
        {
            Name = name;
        }
    }
}
