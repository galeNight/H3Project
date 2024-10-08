using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;

namespace xxx.Repository.Repositories
{
    public class OracleMovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public OracleMovieRepository(DataContext Context)
        {
            _context = Context;
        }

        public Task<Movie>? CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>>? GetAllMovies()
        {
            //var listOFMovies = await _context.Movies.ToListAsync();
            // fake async operation
            await Task.Delay(2000);
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "Horsie 1", DurationMinutes = 99 },
                new Movie { Id = 2, Title = "Horsie 10", DurationMinutes = 49 },
                new Movie { Id = 3, Title = "Horsie 100", DurationMinutes = 25 }
            };
        }

        public Task<Movie>? GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            await Task.Delay(1000);
            return new List<Director>
            {
                new Director { Id = 1, Name = "Oracle Director 1" },
                new Director { Id = 2, Name = "Oracle Director 2" }
            };
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            await Task.Delay(1000);
            return new List<Genre>
            {
                new Genre { Id = 1, Name = "Oracle Genre 1" },
                new Genre { Id = 2, Name = "Oracle Genre 2" }
            };
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId)
        {
            await Task.Delay(1000);
            return new List<Review>
            {
                new Review { Id = 1, Rating = 4, Comment = "Oracle Review 1", MovieId = movieId },
                new Review { Id = 2, Rating = 5, Comment = "Oracle Review 2", MovieId = movieId }
            };
        }
    }
}
