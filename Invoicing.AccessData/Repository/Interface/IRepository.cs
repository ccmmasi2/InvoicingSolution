using System.Linq.Expressions;

namespace Invoicing.AccessData.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> AsQueryable();

        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );
        Task<T> GetOne(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );
        bool Insert(T entity);
        bool Remove(int ID);
        bool Update(T entity);
    }
}
