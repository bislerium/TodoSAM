using SQLite;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace TodoSAM.Models
{
    public class TodoTask: Entity<Guid>
    {
        private const int TaskLength = 100;

        [MaxLength(TaskLength)]
        [AllowNull]
        public string Task { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsImportant { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public static TodoTask Create(string task) => new()
        {
            Id = Guid.NewGuid(),
            Task = task,
            IsCompleted = false,
            IsImportant = false,
            CreatedAt = DateTime.Now,
            CompletedAt = null
        };        

        public static implicit operator TodoTask(string task) => Create(task);

        public bool ToggleCompletion()
        {
            IsCompleted = !IsCompleted;
            CompletedAt = IsCompleted ? DateTime.Now : null;
            return IsCompleted;
        }

        public bool ToggleImportance() => IsImportant = !IsImportant;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
