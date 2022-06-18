using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<Session> _sessionRepository;

        public UserController(IGenericRepository<Session> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Users()
        {
            var sessions = await _sessionRepository.GetAsync(
                                                    q => q.Start > System.DateTime.Now,
                                                    i => i.Include(b => b.Film));
            // Return that sessions to user
            return View(sessions);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
