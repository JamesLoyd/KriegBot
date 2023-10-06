using KriegBot.Data.Entities;

namespace Module.DevFlow.Data.Entities;

public class RepoEntity : BaseEntity
{
    public string Name { get; set; }
    public string RepoLink { get; set; }
    public ICollection<UserEntity> UserEntities { get; set; }
}