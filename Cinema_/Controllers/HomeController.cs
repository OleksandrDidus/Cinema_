using Cinema.Data.Models;
using Cinema.Data.Repository;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<User> _userManager;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Ticket> ticketRepository,
            IGenericRepository<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            int id = (await _userManager.GetAsync(q => q.Login == User.Identity.Name)).FirstOrDefault().Id;
            var sessions = await _ticketRepository.GetAsync(q => q.UserId == id, i => i.Include(b => b.Place).Include(b => b.Session).ThenInclude(x=>x.Film));

            // Return that sessions to user
            return View(sessions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
