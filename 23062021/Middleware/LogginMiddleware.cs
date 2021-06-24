using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace _23062021
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;

        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment environment)
        {
            var schema = await Task.Run(() => Task.FromResult(context.Request.Scheme));
            var host = await Task.Run(() => Task.FromResult(context.Request.Host));
            var path = await Task.Run(() => Task.FromResult(context.Request.Path));
            var queryString = await Task.Run(() => Task.FromResult(context.Request.QueryString));
            string requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            await Task.Run(() =>
            {
                var folder = new System.IO.DirectoryInfo(environment.ContentRootPath).FullName;

                var filePath = Path.Combine(folder, $"Logging/loggin.txt");
                FileMode modeFile;
                //Check file exist
                if (!File.Exists(filePath))
                {
                    modeFile = FileMode.CreateNew;
                }
                else
                {
                    modeFile = FileMode.Append;

                }
                using (FileStream fs = File.Open(filePath, modeFile))
                {
                    using var sr = new StreamWriter(fs);
                    sr.WriteLine($"The schema is {schema}");
                    sr.WriteLine($"The host is {host}");
                    sr.WriteLine($"The path is {path}");
                    sr.WriteLine($"The queryString is {queryString}");
                    sr.WriteLine($"The requestBody is {requestBody}");
                    sr.WriteLine($"\n");

                }
            });
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }


    }

    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogginMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogginMiddleware>();
        }
    }
}
