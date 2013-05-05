using System;
using WebApiTDD.Repository.Repository;

namespace WebApiTDD.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
