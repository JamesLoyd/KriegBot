using System.Linq.Expressions;
using KriegBot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriegBot.Common;

public interface IUnitOfWork : IDisposable
{
    IQueryable<TDomain> Set<TDomain>() where TDomain : BaseEntity;
    void SaveChanges();
    void Add<TDomain>(TDomain entity) where TDomain : BaseEntity;
    TDomain Get<TDomain>(int id) where TDomain : BaseEntity;
    void Delete<TDomain>(int id) where TDomain : BaseEntity;
    IQueryable<TDomain> GetFilteredIQueryable<TDomain>(Expression<Func<TDomain, bool>> filter) where TDomain : BaseEntity;
}

public class UnitOfWork : IUnitOfWork
{
    //TODO Handle multiple contexts
    private readonly DbContext _context;
    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public IQueryable<TDomain> Set<TDomain>() where TDomain : BaseEntity
    {
        return _context.Set<TDomain>();
    }

    public void SaveChanges()
    {
        //TODO maybe make this async?
        _context.SaveChanges();
    }

    public void Add<TDomain>(TDomain entity) where TDomain : BaseEntity
    {
        _context.Set<TDomain>().Add(entity);
    }

    public TDomain Get<TDomain>(int id) where TDomain : BaseEntity
    {
        return Set<TDomain>().SingleOrDefault(x => x.Id == id);
    }

    public IQueryable<TDomain> GetFilteredIQueryable<TDomain>(Expression<Func<TDomain, bool>> filter) where TDomain : BaseEntity
    {
        return Set<TDomain>().Where(filter);
    }

    public void Delete<TDomain>(int id) where TDomain : BaseEntity
    {
        var entity = Get<TDomain>(id);
        _context.Remove(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}