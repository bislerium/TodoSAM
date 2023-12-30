using System.Diagnostics.CodeAnalysis;

namespace TodoSAM.Models
{

    //Example of Rich-Domain Model
    internal class TodoTask
    {
        internal string Id { get; } = Guid.NewGuid().ToString();


        private string _task;
        internal required string Task
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
        internal bool IsCompleted
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

        internal bool IsImportant { get; set; } = false;
        internal DateTime CreatedAt { get; } = DateTime.Now;
        internal DateTime CompletedDateTime { get; private set; } = default;
    }
}
