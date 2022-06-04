using Cinema.Data.interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public class FilmRepository:IFilms
    {
        private readonly AppDBContent appdbcontent;
        
        public FilmRepository(AppDBContent appdbcontent)
        {
            this.appdbcontent = appdbcontent;
        }

        public IEnumerable<Film> AllFilms => appdbcontent.Film;

        public IEnumerable<Film> GetAgeBound => appdbcontent.Film.Include(c => c.age);

        public Film GetFilmById(int id)
        {
            throw new NotImplementedException();
        }

        //public Film GetFilmById(int id) => appdbcontent.Film.FirstOrDefault(p => p.id == id);
    }
}
