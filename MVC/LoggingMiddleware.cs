using Microsoft.AspNetCore.Http;
using MVC.Models.Db;
using MVC.Models.Repository;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MVC
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IBlogRepository _repo;
        private IRequestRepository _logRepo;

        public LoggingMiddleware(RequestDelegate next, IBlogRepository repo, IRequestRepository logRepo)
        {
            _next = next;
            _repo = repo;
            _logRepo = logRepo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogFile(context);
            await LogDB(context);
            await _next.Invoke(context);
        }
        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"{DateTime.Now} Request to: {context.Request.Host.Value + context.Request.Path}");
        }
        private async Task LogFile(HttpContext context)
        {
            string logMessage = $"{DateTime.Now} Request to: {context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Log", "log.txt");
            await File.AppendAllTextAsync(path, logMessage);
        }
        private async Task LogDB(HttpContext context)
        {
            var log = new Request();
            log.Url=context.Request.Host.Value+context.Request.Path;
            log.Date = DateTime.Now;
            await _logRepo.LogRequest(log);
        }
    }
}
