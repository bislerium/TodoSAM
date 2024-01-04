using TodoSAM.Models;

namespace TodoSAM.Services
{
    internal class TodoService
    {

        private readonly ICollection<TodoTask> _tasks;

        internal TodoService(ICollection<TodoTask>? tasks = null)
        {
            _tasks = tasks ?? [];
        }

        internal ICollection<TodoTask> GetAll() => _tasks
            .OrderBy(x => x.IsCompleted)
            .ThenByDescending(x => x.CompletedAt)
            .ToList();

        internal void Add(string task)
        {
            TodoTask todoTask = TodoTask.Create(task);
            _tasks.Add(todoTask);
        }

        internal void Remove(TodoTask task)
        {
            _tasks.Remove(task);
        }

        internal TodoTask GetTaskByID(string id)
        {
            return _tasks.Single(x => x.Id.Equals(id));
        }
    }
}
