using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.interfaces
{
    public interface IFilmGenre
    {
        public IEnumerable<Genre> AllGenres {get;}

    }
}
