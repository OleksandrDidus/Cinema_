using Cinema.Data.Models;
using Cinema.Data.Repository;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class TicketController : Controller
    {
        private readonly IGenericRepository<Session> _sessionRepository;
        private readonly IGenericRepository<Place> _placeRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<User> _userManager;

        public TicketController(IGenericRepository<Session> sessionRepository, IGenericRepository<Place> placeRepository,
            IGenericRepository<Ticket> ticketRepository,
            IGenericRepository<User> userManager)
        {
            _sessionRepository = sessionRepository;
            _placeRepository = placeRepository;
            _userManager = userManager;
            _ticketRepository = ticketRepository;
        }

        // Method to generate ticket purchase page
        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            // Generate model to show user
            var model = new BuyTicketViewModel
            {
                Places = new List<SelectListItem>()
            };

            // Select provided session
            model.Session = (await _sessionRepository.GetAsync(q => q.Id == id, 
                i => i.Include(x => x.Film)
                      .Include(x => x.Tickets))).FirstOrDefault();

            /* Generate available places */

            // Select available places from Database
            var availablePlaces = (await _placeRepository.GetAsync(q => q.Hall == model.Session.Hall)).ToList();
            

            foreach (var ticket in model.Session.Tickets.ToList())
            {
                availablePlaces = availablePlaces.Where(p => p.Id != ticket.PlaceId).ToList();
            }

            model.Places = availablePlaces.ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = $"{p.Row} Row - {p.Seat} Seat",
                    Value = p.Id.ToString()
                };
            });

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(BuyTicketViewModel model)
        {
            try
            {
                Ticket ticket = new Ticket()
                {
                    IsDestroyed = false,
                    SessionId = model.Session.Id,
                    IsPaid = false,
                    Price = model.Session.Price,
                    PlaceId = model.SelectPlaceId,
                    UserId = (await _userManager.GetAsync(q => q.Login == User.Identity.Name))
                        .FirstOrDefault().Id,
                    BookingCode = GetRandomCode(5),
                    SoldTicketQRCode = GetRandomCode(5)
                };

                await _ticketRepository.AddAsync(ticket);

                return Redirect("/Session/Index");
            }
            catch
            {
                return View();
            }
        }

        public static string GetRandomCode(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
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
