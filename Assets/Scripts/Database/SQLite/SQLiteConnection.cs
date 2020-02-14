using Mono.Data.SqliteClient;

namespace Assets.Scripts.Database.SQLite
{
    internal class SQLiteConnection : SqliteConnection
    {
        public SQLiteConnection(string connstring) : base(connstring)
        {
        }
    }
}