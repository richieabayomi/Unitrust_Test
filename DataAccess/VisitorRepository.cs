
using Microsoft.EntityFrameworkCore;
using Unitrust_Test.DataAccess;
using Unitrust_Test.Models;

namespace Unitrust_Test.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visitor>> GetAllAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task<Visitor> GetBynameAsync(string name)
        {
            return await _context.Visitors.FirstOrDefaultAsync(v => v.Name == name);
        }

        public async Task<Visitor> GetByEmailAsync(string email)
        {
            return await _context.Visitors.FirstOrDefaultAsync(v => v.Email.ToLower() == email.ToLower());
        }

        public async Task AddAsync(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
        }

        public async Task<bool> DeleteAsync(string name)
        {
            var visitor = await GetBynameAsync(name);
            if (visitor == null) return false;

            _context.Visitors.Remove(visitor);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
