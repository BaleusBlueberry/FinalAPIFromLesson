using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public abstract class Repository<T>(DALContext context) : IRepository<T> where T : class
{
    
    DbSet<T> DbSet = context.Set<T>();
    public virtual void Add(T entity)
    {
        //context.Products.add
        DbSet.Add(entity);
        context.SaveChanges();
    }

    public virtual T? GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return DbSet.ToList();
    }

    public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public virtual T? FindOne(Expression<Func<T, bool>> predicate)
    {
        return DbSet.SingleOrDefault(predicate);
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
        context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var item = GetById(id) ?? throw new ArgumentException("Item Not Found");
        Delete(item);
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
        context.SaveChanges();
    }

    public virtual void Delete(Expression<Func<T, bool>> predicate)
    {
        DbSet.RemoveRange(FindAll(predicate));
        context.SaveChanges();
    }
}