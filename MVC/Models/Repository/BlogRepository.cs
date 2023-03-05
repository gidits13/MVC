using Microsoft.EntityFrameworkCore;
using MVC.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVC.Models.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context=context;
        }

        public async Task AddUser(User user)
        {
            user.Id = new System.Guid();
            user.JoinDate = DateTime.Now;
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
             return await _context.Users.ToArrayAsync();
        }
    }
}
