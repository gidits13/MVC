using Microsoft.EntityFrameworkCore;
using MVC.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVC.Models.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task LogRequest(Request request)
        {
            request.Id = new Guid();

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
        public async Task<Request[]> GetLogs()
        {
            return await _context.Requests.ToArrayAsync();
        }

    }
}
