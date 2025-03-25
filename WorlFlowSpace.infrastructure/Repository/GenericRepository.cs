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
            var query = _context.Set<T>().AsQueryable();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(T id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(T id, params Expression<Func<T, bool>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await ((DbSet<T>)query).FindAsync(id);
        }
        #endregion

        #region change data
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T id, T entity)
        {
            var entity_value = await _context.Set<T>().FindAsync(id);

            if (entity_value is not null)
            {
                _context.Update(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T id)
        {
            var entity = _context.Set<T>().FindAsync(id);

            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
