using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class TicketController : Controller
    {

        private readonly IGenericRepository<Ticket> _ticketRepository;

        public TicketController(IGenericRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        // GET: TicketController
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Buy(int id)
        {
            var film = (await _ticketRepository.GetAsync(f => f.Id == id, i => i.Include(b => b.Sessions.Film))).FirstOrDefault();
            return View(film);
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
