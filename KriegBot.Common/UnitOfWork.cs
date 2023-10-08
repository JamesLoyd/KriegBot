using System.Linq.Expressions;
using KriegBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriegBot.Common;

public interface IUnitOfWork : IDisposable
{
    IQueryable<TDomain> Set<TDomain>(string contextName) where TDomain : BaseEntity;
    void SaveChanges(string contextName);
    void Add<TDomain>(TDomain entity, string contextName) where TDomain : BaseEntity;
    TDomain Get<TDomain>(int id, string contextName) where TDomain : BaseEntity;
    void Delete<TDomain>(int id, string contextName) where TDomain : BaseEntity;
    IQueryable<TDomain> GetFilteredIQueryable<TDomain>(Expression<Func<TDomain, bool>> filter, string contextName) where TDomain : BaseEntity;
}

public class UnitOfWork : IUnitOfWork
{
    //TODO Handle multiple contexts
    private readonly IEnumerable<KriegDataContext> _contexts;
    public UnitOfWork(IEnumerable<KriegDataContext> contexts)
    {
        _contexts = contexts;
    }

    private DbContext GetContext(string contextName)
    {
        return _contexts.SingleOrDefault(x => x.Context == contextName);
    }

    public IQueryable<TDomain> Set<TDomain>(string contextName) where TDomain : BaseEntity
    {
        var context = GetContext(contextName);
        return context.Set<TDomain>();
    }

    public void SaveChanges(string contextName)
    {
        //TODO maybe make this async?
        var context = GetContext(contextName);
        context.SaveChanges();
    }

    public void Add<TDomain>(TDomain entity, string contextName) where TDomain : BaseEntity
    {
        var context = GetContext(contextName);
        context.Set<TDomain>().Add(entity);
    }

    public TDomain Get<TDomain>(int id, string contextName) where TDomain : BaseEntity
    {
        return Set<TDomain>(contextName).SingleOrDefault(x => x.Id == id);
    }

    public IQueryable<TDomain> GetFilteredIQueryable<TDomain>(Expression<Func<TDomain, bool>> filter, string contextName) where TDomain : BaseEntity
    {
        return Set<TDomain>(contextName).Where(filter);
    }

    public void Delete<TDomain>(int id, string contextName) where TDomain : BaseEntity
    {
        var entity = Get<TDomain>(id, contextName);
        var context = GetContext(contextName);
        context.Remove(entity);
    }

    public void Dispose()
    {
        foreach (var context in _contexts) 
        {
            context.Dispose();
        }
    }
}