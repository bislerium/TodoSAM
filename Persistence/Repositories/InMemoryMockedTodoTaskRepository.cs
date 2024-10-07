using TodoSAM.Models;
using TodoSAM.Utils;

namespace TodoSAM.Persistence.Repositories
{

    // For Demo Purpose
    internal class InMemoryMockedTodoTaskRepository : IRepository<TodoTask, Guid>
    {
        private readonly List<TodoTask> _tasks = TodoTaskSeeder.Seed();

        public Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            var tasks = _tasks
            .OrderBy(x => x.IsCompleted)
            .ThenByDescending(x => x.CompletedAt)
            .AsEnumerable();

            return Task.FromResult(tasks);
        }

        public Task AddAsync(TodoTask task)
        {
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TodoTask task)
        {            
            var existingTask = _tasks.FirstOrDefault(x => x.Id.Equals(task.Id));
            if (existingTask != null)
            {
                existingTask = task;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TodoTask task)
        {
            _tasks.Remove(task);
            return Task.CompletedTask;
        }

        public Task<TodoTask?> GetByIdAsync(Guid id)
        {
            var task = _tasks.FirstOrDefault(x => x.Id.Equals(id));
            return Task.FromResult(task);
        }
    }
}
