using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace MyApp.MiddleWares
{
    public class CustomExeptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public CustomExeptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {

                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                Console.WriteLine(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                watch.Stop();
                await HandleException(context, e, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception e, Stopwatch watch)
        {
            string message = "[ERROR] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + e.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
            Console.WriteLine(message);
            context.Response.ContentType="application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            var result = JsonConvert.SerializeObject(new {error = e.Message}, Formatting.None);

            return context.Response.WriteAsync(result);
        
        }
    }

    public static class CustomExeptionMiddleWareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionMiddleWare>();
        }
    }
}