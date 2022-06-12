using Cinema.Data.Models;
using Cinema.Data.Repository;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class TicketController : Controller
    {
        private readonly IGenericRepository<Session> _sessionRepository;

        public TicketController(IGenericRepository<Session> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        // GET: TicketController/Details/5
        public async Task<IActionResult> Create(int id)
        {
            var model = new BuyTicketViewModel();

            model.Session = (await _sessionRepository.GetAsync(q => q.Id == id, 
                i => i.Include(x => x.Film))).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuyTicketViewModel model)
        {
      

            try
            {
                var modelprop = model.Session;




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
