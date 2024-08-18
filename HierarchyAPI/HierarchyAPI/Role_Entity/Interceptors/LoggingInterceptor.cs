using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace HierarchyAPI.Role_Entity.Interceptors
{
    public class LoggingInterceptor : DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(command.CommandText);
            Console.WriteLine("\n Executing Command at: " + DateTime.Now);

            return result;
        }

    }

}
