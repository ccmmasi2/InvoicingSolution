﻿using Invoicing.AccessData.Strategy.Data;
using Invoicing.AccessData.Strategy.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Invoicing.AccessData.Strategy.Repository.Implementation
{
    public class CrudStrategy<T> : ICrudStrategy<T> where T : class
    {
        private readonly AppDbContext _dbcontext;
        public DbSet<T> dbSet;

        public CrudStrategy(AppDbContext dbcontext)
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

        public async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public bool Remove(T entity)
        {
            dbSet.Remove(entity);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            return _dbcontext.SaveChanges() > 0;
        }
        public async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
