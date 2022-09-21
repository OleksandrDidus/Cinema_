using Cinema.Data;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class CustomModelController : Controller
    {
        private readonly CinemaContext _cinema;

        public CustomModelController(CinemaContext cinema)
        {
            _cinema = cinema;
    }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var values = await _cinema
                    .CustomModel.ToListAsync();

            // Top one
            values = values.OrderByDescending(t => t.sum).Take(5).ToList();

            return View(values);
        }
    }
}
