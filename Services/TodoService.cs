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

        internal IEnumerable<TodoTask> GetAll() => _tasks
            .OrderBy(x => x.IsCompleted);

        internal void Add(string task)
        {
            TodoTask todoTask = new()
            {
                Task = task,
            };
            _tasks.Add(todoTask);
        }

        internal void ToggleCompletion(string id)
        {
            TodoTask task = GetTaskByID(id);
            task.IsCompleted = !task.IsCompleted;
        }

        internal bool ToggleImportant(string id)
        {
            var item = GetTaskByID(id);
            return item.IsImportant = !item.IsImportant;
        }

        internal void Remove(string id)
        {
            TodoTask task = GetTaskByID(id);
            _tasks.Remove(task);
        }

        internal TodoTask GetTaskByID(string id)
        {
            return _tasks.Single(x => x.Id.Equals(id));
        }
    }
}
