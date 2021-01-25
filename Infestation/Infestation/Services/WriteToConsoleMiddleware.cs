using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class WriteToConsoleMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly string _output;

        public WriteToConsoleMiddleware(RequestDelegate next, string output)
        {
            _next = next;
            _output = output;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(_output + "Before");
            await _next(context);
            Console.WriteLine(_output + "After");
        }
    }
}