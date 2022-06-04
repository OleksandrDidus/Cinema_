using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.interfaces
{
    public interface IFilms
    {
        IEnumerable<Film> AllFilms { get;  }
        IEnumerable<Film> GetAgeBound { get; }
        //IEnumerable<Film> GetAllFilm()
        //{

        //}

        Film GetFilmById(int id);
    }
}
