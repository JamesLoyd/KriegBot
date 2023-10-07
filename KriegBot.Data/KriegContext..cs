using KriegBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriegBot.Data;

public class KriegContext : DbContext
{
    public DbSet<ChannelEntity> Channel { get; set; }
    public DbSet<PinsEntity> Pin { get; set; }
    public DbSet<PlatformEntity> Platform { get; set; }
    public string DbPath { get; }

    public KriegContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder)+"/krieg/";
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        DbPath = System.IO.Path.Join(path, "Krieg.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}