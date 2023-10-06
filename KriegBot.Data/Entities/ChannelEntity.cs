namespace KriegBot.Data.Entities;

public class ChannelEntity : BaseEntity
{
    public int PlatformId { get; set; }
    public string Name { get; set; }
    //this is the channel id via the platform, if you can come up with a better name, I would love to hear it! :) 
    public string ChannelId { get; set; }
}