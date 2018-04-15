using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Microsoft.CodeAnalysis.Operations;

namespace CQRS.Command
{
    public class Handlers
    {
        private readonly CommandsContext _context;
        private readonly CommandRepository<AddGroupCommand> _addGroupRepository;
        private readonly CommandRepository<JoinGroupCommand> _joinGroupRepository;
        private readonly CommandRepository<AddUserCommand> _addUserRepository;
        private readonly CommandRepository<RenameUserCommand> _renameUserCommand;

        public Handlers()
        {
            _context = new CommandsContext();
            _addGroupRepository = new CommandRepository<AddGroupCommand>(_context.AddGroupCommands);
            _joinGroupRepository = new CommandRepository<JoinGroupCommand>(_context.JoinGroupCommands);
            _addUserRepository = new CommandRepository<AddUserCommand>(_context.AddUserCommands);
            _renameUserCommand = new CommandRepository<RenameUserCommand>(_context.RenameUserCommands);
        }
        public void Handle(RenameUserCommand command)
        {
            //Check if user has ever been created
            var userHasBeenCreated = _addUserRepository.Find(user => user.UserId == command.UserId);
            if (userHasBeenCreated.Count()!=1) return;

            //Add command to list of commands
            _renameUserCommand.CheckVersionAndAddItem(user => user.UserId == command.UserId, command);
            _context.SaveChanges();

            //Invoke event
            Events.CommandEvents.OnUserRenamed(command);

        }

        public void Handle(JoinGroupCommand command)
        {
            //Check if group has ever been created
            var groupHasBeenCreated = _addGroupRepository.Find(group => group.GroupId == command.GroupId);
            if (!groupHasBeenCreated.Any()) return;

            //Add command to list of commands
            _joinGroupRepository.CheckVersionAndAddItem(group => group.GroupId == command.GroupId, command);
            _context.SaveChanges();

            //Invoke event
            Events.CommandEvents.OnUserJoinedGroup(command);
        }

        public void Handle(AddUserCommand command)
        {
            //Check if user has already been created
            var userHasBeenCreated = _addUserRepository.Find(user => user.UserId == command.UserId);
            if (userHasBeenCreated.Any()) return;

            //Add command to list of commands
            _addUserRepository.CheckVersionAndAddItem(user => user.UserId == command.UserId, command);
            _context.SaveChanges();

            //Invoke event
            Events.CommandEvents.OnUserAdded(command);
        }
        public void Handle(AddGroupCommand command)
        {
            //Check if group has already been created
            var groupHasBeenCreated = _addGroupRepository.Find(group => group.GroupId == command.GroupId);
            if (groupHasBeenCreated.Any()) return;

            //Add command to list of commands
            _addGroupRepository.CheckVersionAndAddItem(group => group.GroupId == command.GroupId, command);
            _context.SaveChanges();

            //Invoke event
            Events.CommandEvents.OnGroupAdded(command);
        }
    }
}
