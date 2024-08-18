using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace HierarchyAPI.Role_Entity.Models
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? ConnectionString;
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
