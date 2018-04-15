public void Handle(RenameUserCommand command){
    //Check if user has ever been created
    var userHasBeenCreated = _addUserRepository.Find(user => user.UserId == command.UserId);
    if (userHasBeenCreated.Count()!=1) return;

    //Add command to list of commands
    _renameUserCommand.CheckVersionAndAddItem(user => user.UserId == command.UserId, command);
    _context.SaveChanges();

    //Invoke event
    Events.CommandEvents.OnUserRenamed(command);
}