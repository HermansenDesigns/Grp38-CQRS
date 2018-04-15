public void Apply(RenameUserCommand entity){
    var user = _context.UserDisplays.Find(entity.UserId);
    user.Name = entity.NewName;
    user.LatestRenameUserCommand = entity;
    _context.SaveChanges();
}
    
