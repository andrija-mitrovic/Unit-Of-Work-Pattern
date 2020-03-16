using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (orderBy!=null)? orderBy(query).ToList():query.ToList();
        }

        public TEntity GetById(int id) 
            => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() 
            => _context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate);

        public void Add(TEntity entity) 
            => _context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) 
            => _context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) 
            => _context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().RemoveRange(entities);

        public void UpdateEntity(TEntity entityToUpdate) 
            => _context.Set<TEntity>().Update(entityToUpdate);

        public void Remove(int id)
            => _context.Set<TEntity>().Remove(_context.Set<TEntity>().Find(id));

    }
}
