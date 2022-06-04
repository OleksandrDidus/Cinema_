using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
