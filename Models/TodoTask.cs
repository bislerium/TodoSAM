using System.Diagnostics.CodeAnalysis;

namespace TodoSAM.Models
{

    // Example of Rich-Domain Model
    internal class TodoTask
    {
        internal string Id { get; }

        private string _task;
        internal string Task
        {
            get
            {
                return _task;
            }

            [MemberNotNull(nameof(_task))]
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Task), "Task cannot be empty!");
                }
                else
                {
                    _task = value;
                }
            }
        }

        internal bool IsCompleted { get; private set; }
        internal bool IsImportant { get; private set; }
        internal DateTime CreatedAt { get; }
        internal DateTime? CompletedAt { get; private set; }

        internal bool ToggleCompletion()
        {
            IsCompleted = !IsCompleted;
            CompletedAt = IsCompleted ? DateTime.Now : null;
            return IsCompleted;
        }

        internal bool ToggleImportance() => IsImportant = !IsImportant;

        internal TodoTask(string id, string task, bool isCompleted, bool isImportant, DateTime createdAt, DateTime? completedAt)
        {
            Id = id;
            Task = task;
            IsCompleted = isCompleted;
            IsImportant = isImportant;
            CreatedAt = createdAt;
            CompletedAt = completedAt;
        }

        internal static TodoTask Create(string task)
        {
            return new TodoTask
                (
                id: Guid.NewGuid().ToString(),
                task: task,
                isCompleted: false,
                isImportant: false,
                createdAt: DateTime.Now,
                completedAt: null
                );
        }

        public override string ToString()
        {
            return $"Id: {Id}, Task: {Task}, IsCompleted: {IsCompleted}, IsImportant: {IsImportant}, CreatedAt: {CreatedAt}, CompletedAt: {CompletedAt}";
        }
    }
}
