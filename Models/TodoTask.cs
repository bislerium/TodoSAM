using System.Diagnostics.CodeAnalysis;

namespace TodoSAM.Models
{

    //Example of Rich-Domain Model
    public class TodoTask
    {
        public string Id { get; } = Guid.NewGuid().ToString();


        private string _task;
        public required string Task
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

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }

            set
            {
                _isCompleted = value;
                if (_isCompleted)
                {
                    CompletedDateTime = DateTime.Now;
                }
                else
                {
                    CompletedDateTime = default;
                }
            }
        }

        public bool IsImportant { get; set; } = false;
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime CompletedDateTime { get; private set; } = default;
    }
}
