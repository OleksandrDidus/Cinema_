using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string KashierRoleName = "Kashier";
            string userRoleName = "user";
            string UsherRoleName = "Usher";

            string KashierEmail = "admin@gmail.com";
            string KashierPassword = "123456";

            string UsherEmail = "usher@gmail.com";
            string UsherPassword = "123456";

            // добавляем роли
            //Role KashierRole = new Role { Id = 1, Name = KashierRoleName };
            //Role userRole = new Role { Id = 2, Name = userRoleName };
            //Role UsherRole = new Role { Id = 3, Name = UsherRoleName };
            //User KashierUser = new User { Id = 1, Login = KashierEmail, Password = KashierPassword, RolesId = KashierRole.Id };
            //User UsherUser = new User { Id = 3, Login = UsherEmail, Password = UsherPassword, RolesId = UsherRole.Id };

            //modelBuilder.Entity<Role>().HasData(new Role[] { KashierRole, userRole });
            //modelBuilder.Entity<User>().HasData(new User[] { KashierUser });
            //modelBuilder.Entity<User>().HasData(new User[] { UsherUser });
            base.OnModelCreating(modelBuilder);
        }

    }
}
