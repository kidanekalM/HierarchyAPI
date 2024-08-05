using Castle.DynamicProxy;
using System.Data.Common;

namespace HierarchyAPI.Interceptors
{
    public class LoggingInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(invocation.InvocationTarget.ToString() + " was invoked.");
        }
    }
}
