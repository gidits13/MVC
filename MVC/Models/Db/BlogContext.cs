using Microsoft.EntityFrameworkCore;

namespace MVC.Models.Db
{
    public sealed class BlogContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> userPosts { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
