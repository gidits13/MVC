using Microsoft.AspNetCore.Mvc;
using MVC.Models.Repository;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetLogs();
            return View(logs);
        }
    }
}
