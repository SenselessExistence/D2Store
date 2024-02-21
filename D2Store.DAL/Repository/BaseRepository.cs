using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity) 
        {
            entity.CreatedDate = DateTime.UtcNow;

            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);

            _context.Set<T>().Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
