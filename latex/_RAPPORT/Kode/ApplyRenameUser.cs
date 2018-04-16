public void Apply(RenameUserCommand entity){
    //Find user relevant to command in local collection
    var user = _context.UserDisplays.Find(entity.UserId);
    //Update local version of user
    user.Name = entity.NewName;
    user.LatestRenameUserCommand = entity;
    _context.SaveChanges();
}
    
