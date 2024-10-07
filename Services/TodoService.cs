using TodoSAM.Models;
using TodoSAM.Persistence;

namespace TodoSAM.Services
{
    public class TodoService
    {

        private readonly ICollection<TodoTask> _tasks;

        private readonly IRepository<TodoTask, Guid> _repository;

        public TodoService(IRepository<TodoTask, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<TodoTask>> GetAll() => _tasks = (await _repository.GetAllAsync()).ToList();

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
