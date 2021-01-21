using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace BibliotecaWeb
{
    public class AutencticMiddleware
    {
        private readonly RequestDelegate _next;

        public AutencticMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var x =  context;
            await _next(context);
        }

    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AutencticMiddleware>();
        }
    }
}