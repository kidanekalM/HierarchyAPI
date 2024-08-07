
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace HierarchyAPI.Interceptors
{
    public class LoggingInterceptor:DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(
                DbCommand command,
                CommandEventData eventData,
                InterceptionResult<DbDataReader> result)
        {
            Console.WriteLine("\n Executing Command at:\n"+DateTime.Now);

            return result;
        }
        
    }

}
