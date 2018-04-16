public void CheckVersionAndAddItem(Func<TEntity, bool> where, TEntity entity){
    //Create collection with commands matching our entity.
    var collection = Find(where);
    var expectedVersion = 0;
    if (collection.Any())
    {
        expectedVersion = collection.ToList().OrderBy(item => item.Version).Last().Version;
    }
    //Test if version supplied by command matches the latest version +1
    if (entity.Version != (expectedVersion + 1))
        throw new ArgumentException();
    AddItem(entity);
}
