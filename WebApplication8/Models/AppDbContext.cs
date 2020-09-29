using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication8.Models
{
    /// <summary>
    /// Класс для работы с базой данных.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
            // Создаем базу данных в случае ее отсутствия.
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполняем начальными данными базу данных.
            modelBuilder.Entity<Session>().HasData(
                new Session[]
                {
                new Session { Id=1, FilmName = "Film 1", SessionDateTime = new DateTime(2020, 9, 28, 15, 00, 00)},
                new Session { Id=2, FilmName = "Film 2", SessionDateTime = new DateTime(2020, 9, 29, 15, 00, 00)},
                new Session { Id=3, FilmName = "Film 3", SessionDateTime = new DateTime(2020, 9, 30, 15, 00, 00)}
                });
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
