using AspNetCore_School_DataAccess_Layer.Context;
using AspNetCore_School_Entity_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_DataAccess_Layer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolContext _schoolContext;
        private DbSet<T> _dbSet;

        public Repository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
            _dbSet = _schoolContext.Set<T>();
        }

        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            this.Delete(_dbSet.Find(id));
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;  //tabloyu alır filtreleri uygulayarak filtrelenmiş verileri dödürür
            if (filter != null)  //filtre varsa
            {
                query = query.Where(filter);
            }
            if (orderby != null)  //sıralama istenmişse
            {
                query = orderby(query);
            }
            foreach (var table in includes)  //ilişkili tablolar istenmişse
            {
                query = query.Include(table);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.AsNoTracking().ToListAsync();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
    }
}
