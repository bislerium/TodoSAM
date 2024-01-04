using System.Text.Json;
using TodoSAM.Models;

namespace TodoSAM.Persistence
{
    internal class TodoTasksPersistence
    {
        private const string FILE_NAME = "todo-tasks";
        private readonly static string _filePath = Path.Combine(FileSystem.CacheDirectory, $"{FILE_NAME}.json");

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { 
            Converters = 
            {
                new TodoTaskJsonConverter() 
            }
        };

        internal static ICollection<TodoTask> Load()
        {
            string value = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<ICollection<TodoTask>>(value, _jsonSerializerOptions) ?? [];
        }

        internal static void Flush(ICollection<TodoTask> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
            System.Diagnostics.Debug.WriteLine(_filePath);
        }
    }
}
