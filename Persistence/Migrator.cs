using SQLite;
using TodoSAM.Models;

namespace TodoSAM.Persistence
{
    // One-time Call to perform any database migrations
    public static class Migrator
    {
        public static async Task Migrate()
        {
            var connection = new SQLiteAsyncConnection(Constants.SqlLite.DatabasePath);
            await connection.CreateTableAsync<TodoTask>();
        }
    }
}
