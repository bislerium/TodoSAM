namespace TodoSAM
{
    public static class Constants
    {
        public static bool IsDemoMode = false;

        public static class SqlLite
        {
            public const string DatabaseFilename = "TodoSQLite.db3";

            public const string DemoDatabaseFilename = "DemoTodoSQLite.db3";

            public const SQLite.SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLite.SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLite.SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLite.SQLiteOpenFlags.SharedCache;

            public static string DatabasePath => IsDemoMode
                        ? Path.Combine(DataDirectory, DemoDatabaseFilename)
                        : Path.Combine(DataDirectory, DatabaseFilename);
        }

        public static class Demo
        {
            public const int MaxRecords = 10;
            public const int MinRecords = 4;
            public const int MaxTaskLength = 50;
            public const int MinTaskLength = 5;
            public const int MaxTaskCompletionRecords = MaxRecords / 2;
            public const int MinTaskCompletionRecords = MinRecords / 2;
            public const int MaxImportantTaskRecords = MaxRecords / 2;
            public const int MinImportantTaskRecords = MaxRecords / 2;
        }
        
        public static readonly string DataDirectory =  FileSystem.AppDataDirectory;
    }
}
