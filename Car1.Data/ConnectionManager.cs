using Car1.Domain;
using System.Configuration;
using System.Data.SqlClient;

namespace Car1.Data
{
    public class ConnectionManager : IConnectionManager
    {
        ISettings _settings;

        public ConnectionManager(ISettings settings)
        {
            _settings = settings;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = _settings.GetConnectionString();
            var connection= new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }

    public interface IConnectionManager
    {
        SqlConnection GetConnection();
    }
}
