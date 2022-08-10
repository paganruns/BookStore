using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public CustomExceptionMiddleWare(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                string message = "[Request] HTTP" + context.Request.Method + " " + context.Request.Path;
                _logger.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Response] Http" + context.Request.Method + " " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                _logger.Write(message);
            }
            catch (System.Exception ex)
            {
                watch.Stop();
                await HandleExceptions(context, ex, watch);
            }


        }

        private Task HandleExceptions(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[fatal error] HTTP " + context.Request.Method + " " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _logger.Write(message);
            

            var result = JsonConvert.SerializeObject(new { fatalerror = ex.Message },formatting: Formatting.None);
            _logger.Write(result);

            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddleWareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleWare>();
        }
    }
}