using Cinema.Data.interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public class GenreRepository : IFilmGenre
    {
        private readonly AppDBContent appdbcontent;
        public GenreRepository(AppDBContent appdbcontent)
        {
            this.appdbcontent = appdbcontent;
        }

        public IEnumerable<Genre> AllGenres => appdbcontent.Genre;
    }
}
