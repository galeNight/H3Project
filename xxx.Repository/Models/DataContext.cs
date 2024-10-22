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
                new Movie { Id = 1, Title = "Jurassic Park", DurationMinutes = 127, GenreId = 12, DirectorId = 1 },
                new Movie { Id = 2, Title = "Interstellar", DurationMinutes = 169, GenreId = 10, DirectorId = 2 },
                new Movie { Id = 3, Title = "Hugo", DurationMinutes = 126, GenreId = 8, DirectorId = 3 },
                new Movie { Id = 4, Title = "The Martian", DurationMinutes = 144, GenreId = 4, DirectorId = 4 },
                new Movie { Id = 5, Title = "The Lord of the Rings: The Return of the King", DurationMinutes = 201, GenreId = 5, DirectorId = 5 },
                new Movie { Id = 6, Title = "The Matrix", DurationMinutes = 136, GenreId = 10, DirectorId = 6 },
                new Movie { Id = 7, Title = "Fast & Furious", DurationMinutes = 107, GenreId = 12, DirectorId = 7 },
                new Movie { Id = 8, Title = "Kill Bill: Vol. 1", DurationMinutes = 111, GenreId = 1, DirectorId = 8 },
                new Movie { Id = 9, Title = "Avatar", DurationMinutes = 162, GenreId = 5, DirectorId = 9},
                new Movie { Id = 10, Title = "The Mummy", DurationMinutes = 111, GenreId = 6, DirectorId = 10},
                new Movie { Id = 11, Title = "Night at the Museum", DurationMinutes = 108, GenreId = 3, DirectorId = 11},
                new Movie { Id = 12, Title = "Transformers ", DurationMinutes = 144, GenreId = 1, DirectorId = 12},
                new Movie { Id = 13, Title = "White House Down", DurationMinutes = 131, GenreId = 12, DirectorId = 13}
                );

            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, Name = "Steven Spielberg" },
                new Director { Id = 2, Name = "Christopher Nolan" },
                new Director { Id = 3, Name = "Martin Scorsese" },
                new Director { Id = 4, Name = "Ridley Scott" },
                new Director { Id = 5, Name = "Peter Jackson" },
                new Director { Id = 6, Name = "Lana Wachowski" },
                new Director { Id = 7, Name = "Justin Lin" },
                new Director { Id = 8, Name = "Quentin Tarantino" },
                new Director { Id = 9, Name = "James Cameron" },
                new Director { Id = 10, Name = "Alex Kurtzman" },
                new Director { Id = 11, Name = "Shawn Levy" },
                new Director { Id = 12, Name = "Michael Bay" },
                new Director { Id = 13, Name = "Roland Emmerich" }
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
                new Genre { Id = 10, Name = "sci-fi" },
                new Genre { Id = 11, Name = "sports" },
                new Genre { Id = 12, Name = "thriller" },
                new Genre { Id = 13, Name = "Western" }
                );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Rating = 5, Comment ="Greate Movie", MovieId = 1},
                new Review { Id = 2, Rating = 3, Comment = "Not bad.", MovieId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }

}
