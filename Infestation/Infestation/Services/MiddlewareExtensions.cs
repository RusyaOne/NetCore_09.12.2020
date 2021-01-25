using Microsoft.AspNetCore.Builder;

namespace Infestation.Services
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteToConsole(this IApplicationBuilder app, string output)
        {
            return app.UseMiddleware<WriteToConsoleMiddleware>(output);
        }
    }
}