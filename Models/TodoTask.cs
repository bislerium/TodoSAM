namespace TodoSAM.Models
{
    internal class TodoTask
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public required string Task { get; set; }

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

        public DateTime CompletedDateTime { get; private set; } = default;
    }
}
