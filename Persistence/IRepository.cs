using TodoSAM.Models;

namespace TodoSAM.Persistence
{
    public interface IRepository<T, U> where T : Entity<U> where U : IEquatable<U>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T task);
        Task UpdateAsync(T task);
        Task DeleteAsync(T task);
        Task<T?> GetByIdAsync(U id);
    }
}
