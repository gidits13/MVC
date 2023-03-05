using MVC.Models.Db;
using System.Threading.Tasks;

namespace MVC.Models.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
