using SQLite;
using TodoSAM.Models;

namespace TodoSAM.Persistence.Repositories
{
    internal class SqLiteTodoTaskRepository : IRepository<TodoTask, Guid>
    {
        public SQLiteAsyncConnection _database = new(Constants.SqlLite.DatabaseFilename, Constants.SqlLite.Flags);

        public async Task<IEnumerable<TodoTask>> GetAllAsync() => await _database.Table<TodoTask>()
            .OrderBy(x => x.IsCompleted)
            .ThenByDescending(x => x.CompletedAt)
            .ToListAsync();

        public async Task AddAsync(TodoTask task)
        {
            await _database.InsertAsync(task);
        }

        public async Task UpdateAsync(TodoTask task)
        {
            await _database.UpdateAsync(task);
        }

        public async Task DeleteAsync(TodoTask task)
        {
            await _database.DeleteAsync(task);
        }

        public async Task<TodoTask?> GetByIdAsync(Guid id)
        {
            return await _database.Table<TodoTask>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
