using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;

namespace HierarchyAPI.Models
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Postgres");
        }
        public IDbConnection CreateConnection()
        {
           return new NpgsqlConnection(ConnectionString); 
        }
    }

}
