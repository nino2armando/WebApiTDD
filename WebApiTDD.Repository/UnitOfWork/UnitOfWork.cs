using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WebApiTDD.Context;
using WebApiTDD.Repository.Repository;

namespace WebApiTDD.Repository.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
        private readonly IDbContext _context;
        private readonly Dictionary<Type, Object> _repositories;
        private bool _disposed;

        public UnitOfWork()
        {
            _context = new TContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof (TEntity)))
            {
                return _repositories[typeof (TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity),repository);
            return repository;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                exception.Entries.First().Reload();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
