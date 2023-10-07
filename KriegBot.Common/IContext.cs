using Microsoft.EntityFrameworkCore;

namespace KriegBot.Common;

public abstract class KriegDataContext : DbContext
{
    public abstract string Context { get; }
}