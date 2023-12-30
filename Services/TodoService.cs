using TodoSAM.Models;

namespace TodoSAM.Services
{
    internal class TodoService
    {

        private readonly ICollection<TodoTask> _tasks;

        public TodoService()
        {
            _tasks = [];
        }

        public IEnumerable<TodoTask> GetAll() => _tasks
            .OrderBy(x => x.IsCompleted);

        public void Add(string task)
        {
            TodoTask todoTask = new()
            {
                Task = task,
            };
            _tasks.Add(todoTask);
        }

        public void ToggleCompletion(string id)
        {
            TodoTask task = GetTaskByID(id);
            task.IsCompleted = !task.IsCompleted;
        }

        public bool ToggleImportant(string id)
        {
            var item = GetTaskByID(id);
            return item.IsImportant = !item.IsImportant;
        }

        public void Remove(string id)
        {
            TodoTask task = GetTaskByID(id);
            _tasks.Remove(task);
        }

        private TodoTask GetTaskByID(string id)
        {
            return _tasks.Single(x => x.Id.Equals(id));
        }
    }
}
