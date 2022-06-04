using Cinema.Data.interfaces;
using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Mocks
{
    public class MockGenre : IFilmGenre
    {
        public IEnumerable<Genre> AllGenres 
        {
            get
            {
                return new List<Genre> { new Genre { name = "Комедія" },new Genre { name = "Бойовик" },
                    new Genre { name = "Хорор" },new Genre { name = "Фентезі" },new Genre { name = "новый жанр" },new Genre { name = "Лупа і пупа" }};
            }
        }
    }
}
