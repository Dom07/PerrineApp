using System.Data;
using System.Data.SQLite;

namespace PerrineApp.DataAccess
{
    public class SqliteDataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;
        public SqliteDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string LoadConnectionString() => _configuration.GetConnectionString("Default");

        public IDbConnection CreateConnection() => new SQLiteConnection(LoadConnectionString());
    }
}
