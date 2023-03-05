using MVC.Models.Db;
using System.Threading.Tasks;

namespace MVC.Models.Repository
{
    public interface IRequestRepository
    {
        Task LogRequest(Request request);
        Task<Request[]> GetLogs();
    }
}
