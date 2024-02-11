using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using TodoSAM.Services;

namespace TodoSAM.Persistence
{
    internal class TodoTasksPersistenceBackgroundTask(TodoService todoService) : BackgroundService
    {
        private readonly TodoService _todoService = todoService;

        private Timer? _timer;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(Save, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return base.StopAsync(cancellationToken);
        }

        private int count = 0;
        private void Save(object? state)
        {
            Debug.WriteLine($"{count++}");

            if (GlobalUpdateState.IsUpdateNeeded)
            {

                var todo = _todoService.GetAll();
                Debug.WriteLine($"-------> {count++}");
                TodoTasksPersistence.Flush(todo);
                GlobalUpdateState.ToggleUpdateNeeded();
            }
        }
    }
}
