using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Invoicing.AccessData.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbcontext;
        public DbSet<T> dbSet;

        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.dbSet = _dbcontext.Set<T>();
        }

        public async Task<IQueryable<T>> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var ip in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var ip in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public bool Insert(T entity)
        {
            dbSet.AddAsync(entity);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool Remove(int ID)
        {
            T entityToDelete = dbSet.Find(ID);
            dbSet.Remove(entityToDelete);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            dbSet.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;

            var _return = _dbcontext.SaveChanges() > 0;

            return _return;
        }
    }
}
