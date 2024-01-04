using System.Text.Json.Serialization;
using System.Text.Json;
using TodoSAM.Models;

namespace TodoSAM.Persistence
{
    internal class TodoTaskJsonConverter : JsonConverter<TodoTask>
    {
        public override TodoTask Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Dictionary<string, object> pararg = new (6);

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case nameof(TodoTask.Id):
                        pararg[nameof(TodoTask.Id)] = reader.GetString()!;
                        break;
                    case nameof(TodoTask.Task):
                        pararg[nameof(TodoTask.Task)] = reader.GetString()!;
                        break;
                    case nameof(TodoTask.IsCompleted):
                        pararg[nameof(TodoTask.IsCompleted)] = reader.GetBoolean();
                        break;
                    case nameof(TodoTask.IsImportant):
                        pararg[nameof(TodoTask.IsImportant)] = reader.GetBoolean();
                        break;
                    case nameof(TodoTask.CreatedAt):
                        pararg[nameof(TodoTask.CreatedAt)] = reader.GetDateTime();                        
                        break;
                    case nameof(TodoTask.CompletedAt):
                        pararg[nameof(TodoTask.CompletedAt)] = reader.GetDateTime();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new TodoTask(
                (string) pararg[nameof(TodoTask.Id)],
                (string) pararg[nameof(TodoTask.Task)],
                (bool) pararg[nameof(TodoTask.IsCompleted)], 
                (bool) pararg[nameof(TodoTask.IsImportant)], 
                (DateTime) pararg[nameof(TodoTask.CreatedAt)],
                pararg.TryGetValue(nameof(TodoTask.CreatedAt), out object? value) ? value as DateTime? : null
                );
        }

        public override void Write(Utf8JsonWriter writer, TodoTask value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Id", value.Id);
            writer.WriteString("Task", value.Task);
            writer.WriteBoolean("IsCompleted", value.IsCompleted);
            writer.WriteBoolean("IsImportant", value.IsImportant);
            writer.WriteString("CreatedAt", value.CreatedAt);
            if (value.CompletedAt is not null)
            {
                writer.WriteString("CompletedAt", (DateTime) value.CompletedAt);
            }
            
            writer.WriteEndObject();
        }
    }
}
