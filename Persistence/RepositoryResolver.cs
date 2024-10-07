using TodoSAM.Models;
using TodoSAM.Persistence.Repositories;

namespace TodoSAM.Persistence
{
    public static class RepositoryResolver
    {
        public static IRepository<TodoTask, Guid> GetTodoTaskRepository()
        {
            return Constants.IsDemoMode
                ? new InMemoryMockedTodoTaskRepository() 
                : new SqLiteTodoTaskRepository();
        }
    }
}
