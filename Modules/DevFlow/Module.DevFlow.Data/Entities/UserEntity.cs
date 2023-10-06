using KriegBot.Data.Entities;

namespace Module.DevFlow.Data.Entities;

public class UserEntity : BaseEntity
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string GithubName { get; set; }
    public Role Role { get; set; }
    public ICollection<RepoEntity> RepoEntities { get; set; }
}