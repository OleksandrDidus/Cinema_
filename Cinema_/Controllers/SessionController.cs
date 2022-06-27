using Cinema.Data;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class SessionController : Controller
    {
        private readonly IGenericRepository<Session> _sessionRepository;
        private readonly CinemaContext _dbContext;

        public SessionController(IGenericRepository<Session> sessionRepository, CinemaContext dbContext)
        {
            _sessionRepository = sessionRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //System.Collections.Generic.List<Session> studentList = _dbContext.Sessions.FromSqlRaw("Select * from Students")
            //            .ToList<Session>();
            // Get all future sessions
            //_sessionRepository. .Initialize(false);
            //context.Database.Log = Console.WriteLine;
            var sessions = await _sessionRepository.GetAsync(
                                                    q => q.Start > System.DateTime.Now,
                                                    i => i.Include(b => b.Film));

            // Return that sessions to user
            return View(sessions);
        }
        
        public async Task<IActionResult> Info(int id)
        {
            // Return film Details
            var film = (await _sessionRepository.GetAsync(
                            f => f.Id == id,
                            i => i.Include(b => b.Film).ThenInclude(u => u.Genres))).FirstOrDefault();
                            

            // In case when model is not valid return validation messages
            return View(film);
        }
    }
}
