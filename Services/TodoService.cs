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
            //throw new NotImplementedException();
            if (string.IsNullOrWhiteSpace(task))
                return;

            TodoTask todoTask = new()
            {
                Task = task,
            };
            _tasks.Add(todoTask);
        }

        public void ToggleCompletion(string id)
        {
            TodoTask task = GetTasksByID(id);
            task.IsCompleted = !task.IsCompleted;
        }

        public void Remove(string id)
        {
            TodoTask task = GetTasksByID(id);
            _tasks.Remove(task);
        }

        private TodoTask GetTasksByID(string id)
        {
            return _tasks.Single(x => x.Id.Equals(id));
        }
    }
}
