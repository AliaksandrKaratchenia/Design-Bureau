using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Design_Bureau.DAL.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        Task Delete(T entity);

        Task Update(T entity);
    }
}
