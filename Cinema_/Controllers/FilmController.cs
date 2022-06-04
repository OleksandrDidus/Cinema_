using Cinema.Data;
using Cinema.Data.interfaces;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_.Controllers
{
    public class FilmController:Controller
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

        // GET: TvShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvShows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] Film film)
        {
            if (ModelState.IsValid)
            {
               await _filmRepository.AddAsync(film); 
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

    }
}
