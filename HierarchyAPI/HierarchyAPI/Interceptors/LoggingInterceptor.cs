
namespace HierarchyAPI.Interceptors
{
    public class LoggingInterceptorMiddleware:IMiddleware
    {

        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            Console.WriteLine(context.GetEndpoint() + " invoked.");
            await next(context);
            Console.WriteLine(context.GetEndpoint() + " Completed.");

        }
    }

}
