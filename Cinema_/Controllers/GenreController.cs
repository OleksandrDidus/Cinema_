using Cinema.Data;
using Cinema.Data.interfaces;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_.Controllers
{
    public class GenreController : Controller
    {
        AppDBContent db;

        public GenreController(AppDBContent context)
        {
            db = context;
        }

        //public IActionResult Genres()
        //{
        //    var genres = _allgenres.AllGenres;
        //    return View(genres);
        //}
        public async Task<IActionResult> Genres()
        {
            return View();
        }


    }
}
    


        


