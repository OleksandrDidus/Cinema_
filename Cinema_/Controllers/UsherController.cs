using Cinema.Data;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_.Controllers
{
    public class UsherController : Controller
    {
        AppDBContent db;
        public UsherController(AppDBContent context)
        {
            db = context;
        }
        //public async Task<IActionResult> Usher(int? id =1)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await db.Film.FirstOrDefaultAsync(m => m.id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}




        //public async Task<IActionResult> Genres()
        //{
        //    return View(await db.Genre.ToListAsync());
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Genre genre)
        //{
        //    db.Genre.Add(genre);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Genres");
        //}
    }
}
