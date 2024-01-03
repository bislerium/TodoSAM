using TodoSAM.Models;

namespace TodoSAM.Services
{
    internal class TodoService
    {

        private readonly ICollection<TodoTask> _tasks;

        internal TodoService()
        {
            _tasks = [];
        }

        internal TodoService(ICollection<TodoTask> tasks)
        {
            _tasks = tasks;
        }

        internal ICollection<TodoTask> GetAll() => _tasks
            .OrderBy(x => x.IsCompleted)
            .ThenByDescending(x => x.CompletedDateTime)
            .ToList();

        internal void Add(string task)
        {
            TodoTask todoTask = new()
            {
                Task = task,
            };
            _tasks.Add(todoTask);
        }

        internal void ToggleCompletion(TodoTask task)
        {
            task.IsCompleted = !task.IsCompleted;
        }

        internal bool ToggleImportant(TodoTask task)
        {
            return task.IsImportant = !task.IsImportant;
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
