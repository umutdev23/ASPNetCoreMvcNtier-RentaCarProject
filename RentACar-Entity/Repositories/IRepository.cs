
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Repositories
{
    public interface IRepository <T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> Get(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes); //Detaylı filtreler yazmak için
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);
    }
}
