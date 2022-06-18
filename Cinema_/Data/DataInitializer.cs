using System;
using Cinema.Enums;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cinema.Data
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<CinemaContext>();
            
            // Check database exiting
            var isExists = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator
                           && await databaseCreator.ExistsAsync();

            // Automatically migrate
            await context!.Database.MigrateAsync();

            // When we run first time then populate database by Initial Values
            if (!isExists)
            {
                var userManager = scope.ServiceProvider.GetService<IGenericRepository<User>>();
                var roleManager = scope.ServiceProvider.GetService<IGenericRepository<Role>>();
                var genreManager = scope.ServiceProvider.GetService<IGenericRepository<Genre>>();
                var movieManager = scope.ServiceProvider.GetService<IGenericRepository<Film>>();
                var sessionManager = scope.ServiceProvider.GetService<IGenericRepository<Session>>();
                var placeManager = scope.ServiceProvider.GetService<IGenericRepository<Place>>();

                // Roles definition
                await roleManager.AddAsync(new Role { Name = nameof(Roles.User) });
                await roleManager.AddAsync(new Role { Name = nameof(Roles.Usher) });
                await roleManager.AddAsync(new Role { Name = nameof(Roles.Cashier) });

                // Users definition
                await userManager.AddAsync(new User
                {
                    Name = "User Taylor",
                    DateOfBirth = new DateTime(2002, 2, 14),
                    Login = "User@gmail.com",
                    Password = "password",
                    RoleId = (int)Roles.User
                });

                await userManager.AddAsync(new User
                {
                    Name = "Cashier John",
                    DateOfBirth = new DateTime(2002, 2, 14),
                    Login = "Cashier@gmail.com",
                    Password = "password",
                    RoleId = (int)Roles.Cashier
                });

                await userManager.AddAsync(new User
                {
                    Name = "Usher Jessica",
                    DateOfBirth = new DateTime(2002, 2, 14),
                    Login = "Usher@gmail.com",
                    Password = "password",
                    RoleId = (int)Roles.Usher
                });

                // Genres
                await genreManager.AddAsync(new Genre { Name = "Adventure" });
                await genreManager.AddAsync(new Genre { Name = "Comedy" });

                // Film
                await movieManager.AddAsync(
                new Film
                {
                    Name = "Топ Ґан: Меверік",
                    Description = "Піт «Меверік» Мітчелл більше 30 років залишається одним з кращих пілотів ВМФ: безстрашний льотчик-випробувач, він розширює межі можливого" +
                    " і старанно уникає підвищення в званні, яке змусило б його приземлитися назавжди. " +
                    "Приступивши до підготовки загону випускників Топ Ган для спеціальної місії, подібної до якої ніколи не було, Меверик зустрічає лейтенанта Бредлі Бредшоу, сина свого покійного друга, лейтенанта Ніка Бредшоу. " +
                    "Попереду - невизначеність, за спиною - привиди минулого. Меверік змушений протистояти своїм глибинним страхам, які загрожують ожити в рамках місії, що вимагає виняткової самовідданості від тих, хто буде призначений на виліт.",
                    Studio = "Paramount Pictures, Skydance Productions, Jerry Bruckheimer Films",
                    ReleaseDate = new DateTime(2000, 2, 2),
                    Director = "Топ Ґан: Меверік",
                    ImageUrl = "https://filmax.ua/thumb/2/images/covers/9f4df1c72cd36c27790ec0aec9d00787.jpg",
                    Genres = new List<Genre>
                    {
                        new Genre{ Name = "Драма"},
                        new Genre{ Name = "Бойовик"}
                    }
                });

                // Session
                await sessionManager.AddAsync(
                new Session
                {
                    FilmId = 1,
                    Hall = Hall.First,
                    Price = 100,
                    Start = DateTime.Now.AddDays(3),
                    End = DateTime.Now.AddDays(3).AddHours(2),
                });

                // Populate places
                for (int hall = (int)Hall.First; hall <= (int)Hall.Third; hall++)
                {
                    for (int row = 1; row <= 3; row++)
                    {
                        for (int seat = 1; seat <= 3; seat++)
                        {
                            await placeManager.AddAsync(
                            new Place
                            {
                                Hall = (Hall)hall,
                                Row = row,
                                Seat = seat,
                            });
                        }
                    }
                }
            }
        }
    }
}
