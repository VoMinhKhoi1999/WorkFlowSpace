using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.Core.Interface
{
    public interface IGenericRepository <T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] includes);

        Task<T> GetByIdAsync(T id, params Expression<Func<T, bool>>[] includes);
        Task<T> GetAsync(T id);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T id, T entity);
        Task DeleteAsync(T id);
    }
}
