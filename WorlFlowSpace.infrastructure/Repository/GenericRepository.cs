using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data;

namespace WorkFlowSpace.infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region connect db
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region get
        public IEnumerable<T> GetAll() => _context.Set<T>().AsNoTracking().ToList();

        public IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] includes) => _context.Set<T>().AsNoTracking().ToList();

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] includes)
        {
            var result = _context.Set<T>().AsQueryable();

            foreach (var item in includes)
            {
                result = result.Include(item);
            }

            return await result.ToListAsync();
        }

        public async Task<T> GetAsync(T id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(T id, params Expression<Func<T, bool>>[] includes)
        {
            IQueryable<T> result = _context.Set<T>();

            foreach (var item in includes)
            {
                result = result.Include(item);
            }

            return await ((DbSet<T>)result).FindAsync(id);
        }
        #endregion

        #region change data
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result is not null)
            {
                _context.Update(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result is not null)
            {
                _context.Remove(result);

                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
