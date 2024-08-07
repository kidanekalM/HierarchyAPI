using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace HierarchyAPI.Models
{
    public class DapperContext:DbContext
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
