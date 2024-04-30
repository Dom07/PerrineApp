using System.Data;

namespace PerrineApp.DataAccess
{
    public interface IDataAccess
    {
        public IDbConnection CreateConnection();
    }
}
