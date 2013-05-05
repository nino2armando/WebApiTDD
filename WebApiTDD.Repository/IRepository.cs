using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiTDD.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
