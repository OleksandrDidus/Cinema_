using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class FilmController : Controller
    {
        private readonly IGenericRepository<Film> _filmRepository;

        public FilmController(IGenericRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var films = await _filmRepository.GetAsync();
            return View(films);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
               await _filmRepository.AddAsync(film); 
                return RedirectToAction(nameof(Index));
            }

            // In case when model is not valid return validation messages
            return View(film);
        }

        public async Task<IActionResult> Details(int id)
        {
            // Return film Details
            var film = (await _filmRepository.GetAsync(f => f.Id == id,
                            i => i.Include(b => b.Genres))).FirstOrDefault();

            // In case when model is not valid return validation messages
            return View(film);
        }
    }
}
