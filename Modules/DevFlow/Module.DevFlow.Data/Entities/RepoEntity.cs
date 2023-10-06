namespace Module.DevFlow.Data.Entities;

public class RepoEntity
{
    public string Name { get; set; }
    public string RepoLink { get; set; }
    public ICollection<UserEntity> UserEntities { get; set; }
}