using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;

namespace Design_Bureau.DAL.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DesignBureauDbContext designBureauDbContext)
        {
            DesignBureauDbContext = designBureauDbContext;
            _dbSet = DesignBureauDbContext.Set<T>();
        }

        DesignBureauDbContext DesignBureauDbContext { get; set; }

        public T Get(int id)
        {
            return _dbSet.Where(e => e.Id == id).SingleOrDefault();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task Insert(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await Save();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
        }

        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Save();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        private Task Save()
        {
            return DesignBureauDbContext.SaveChangesAsync();
        }
    }
}
