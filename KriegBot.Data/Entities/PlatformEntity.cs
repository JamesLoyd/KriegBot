namespace KriegBot.Data.Entities;

public class PlatformEntity : BaseEntity
{
    public string Name { get; set; }
    public string Token { get; set; } // this token is your bot token, Krieg can run multiple bots if need be
}