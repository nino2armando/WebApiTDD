using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using WebApiTDD.Repository.UnitOfWork;

namespace WebApiTDD.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            _dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual System.Linq.IQueryable<TEntity> All()
        {
            return _dbSet;
        }

        public virtual System.Linq.IQueryable<TEntity> Find(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> AllReadOnly()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
