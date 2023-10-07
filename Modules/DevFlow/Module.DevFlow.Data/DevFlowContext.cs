using KriegBot.Common;
using Microsoft.EntityFrameworkCore;
using Module.DevFlow.Data.Entities;

namespace Module.DevFlow.Data;

public class DevFlowContext: KriegDataContext
{
    public DbSet<RepoEntity> Repo { get; set; }
    public DbSet<UserEntity> User { get; set; }
    
    public string DbPath { get; }
    public override string Context { get; }


    public DevFlowContext()
    {
        Context = "DevFlow";
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder)+"/krieg/";
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        DbPath = System.IO.Path.Join(path, "DevFlow.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}