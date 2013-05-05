using System.Data.Entity;

namespace WebApiTDD.Repository
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

        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<TEntity> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<TEntity> Find(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
