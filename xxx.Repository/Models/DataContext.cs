using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;

namespace xxx.Repository.Models
{
    
    public class DataContext : DbContext
    {
       // private readonly DbContextOptions _dbContextOptions;

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
           // _dbContextOptions = dbContextOptions;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData( 
                new Movie { Id = 1, Title = "Fight With The Mongols",DurationMinutes = 33, GenreId = 1, DirectorId = 1},
                new Movie {Id = 2, Title = "Fight With The Small Mongols - The Movie", DurationMinutes = 33,GenreId = 1, DirectorId = 2},
                new Movie { Id = 3, Title = "Fight With The Big Mongols - The End", DurationMinutes = 33,GenreId = 2, DirectorId = 2});

            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, Name = "Steven Spielberg" },
                new Director { Id = 2, Name = "Christopher Nolan" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "adventure" },
                new Genre { Id = 3, Name = "comedy" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "fantasy" },
                new Genre { Id = 6, Name = "horror" },
                new Genre { Id = 7, Name = "musicals" },
                new Genre { Id = 8, Name = "mystery" },
                new Genre { Id = 9, Name = "romance" },
                new Genre { Id = 10, Name = "science fiction" },
                new Genre { Id = 11, Name = "sports" },
                new Genre { Id = 12, Name = "thriller" },
                new Genre { Id = 13, Name = "Western" }
                );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Rating = 5, Comment ="Greate Movie", MovieId = 1},
                new Review { Id = 2, Rating = 3, Comment = "Not bad.", MovieId = 2 });

            base.OnModelCreating(modelBuilder);
        }
    }

}
