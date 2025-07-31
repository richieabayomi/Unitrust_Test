using Unitrust_Test.Models;

namespace Unitrust_Test.DataAccess
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllAsync();
        Task<Visitor> GetBynameAsync(string name);
        Task<Visitor> GetByEmailAsync(string email);
        Task AddAsync(Visitor visitor);
        Task<bool> DeleteAsync(string username);
        Task SaveChangesAsync();
    }
}
