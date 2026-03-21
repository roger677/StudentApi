using Microsoft.EntityFrameworkCore;

namespace School.Infrastructure.Core
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}