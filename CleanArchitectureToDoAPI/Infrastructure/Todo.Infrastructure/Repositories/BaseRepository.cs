using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infrastructure.Context;
using Todo.Infrastructure.Interface;

namespace Todo.Infrastructure.Repositories
{



    public class BaseRepository<T> : IBaseRepository<T> where T : class

    {
        private readonly TodoDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TodoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (typeof(T) == typeof(TodoItem))
            {
                query = query.Include(t => ((TodoItem)(object)t).Category);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;


        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<IEnumerable<T>> SearchTodoAsync(string searchTerm)
        {
            if (typeof(T) == typeof(TodoItem))
            {
                return await _context.Set<TodoItem>()
                    .Include(t => t.Category)
                    .Where(b => EF.Functions.Like(b.Title, $"%{searchTerm}%"))
                    .Cast<T>()
                    .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Search is only implemented for TodoItem");
            }
        }
    }
}
