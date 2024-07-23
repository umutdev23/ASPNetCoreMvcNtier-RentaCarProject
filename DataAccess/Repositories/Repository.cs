using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess.Contexts;
using RentACar_Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly RentACarDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(RentACarDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            //_context.SaveChanges();       //UnitOfWork tarafından yapılacak
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter =null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = _dbSet.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public List<T> GetAll()
        {

            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> GetByIdAsync( Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(orderby != null)
            {
                query = orderby(query);
            }
            foreach(var table in includes)
            {
                query = query.Include(table);
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(orderby != null)
            {
                query = orderby(query);
            }
            foreach(var table in includes)
            {
                query = query.Include(table);
            }
            return await query.ToListAsync();
        }

    }
}
