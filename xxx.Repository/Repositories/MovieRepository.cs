using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;

namespace xxx.Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext Context)
        {
            _context = Context;
        }

        public async Task<Movie>? CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>>? GetAllMovies()
        {
            var listOFMovies = await _context.Movies.ToListAsync();
            return listOFMovies;
        }

        public async Task<Movie>? GetMovieById(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteById(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x=>x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId)
        {
            return await _context.Reviews.Where(r => r.MovieId == movieId).ToListAsync();
        }
        public async Task<Movie>? UpdateMovie(Movie movie)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(movie.Title))
                throw new ArgumentException("Movie title cannot be empty.");

            if (movie.DurationMinutes <= 0)
                throw new ArgumentException("Duration must be a positive integer.");

            // Find the existing movie in the database
            var existingMovie = await _context.Movies
                .Include(m => m.Director)
                .Include(m => m.Genre)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync(x => x.Id == movie.Id);

            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with id {movie.Id} not found.");
            }

            // Update the movie details
            existingMovie.Title = movie.Title;
            existingMovie.DurationMinutes = movie.DurationMinutes;

            // Update director
            if (movie.DirectorId != existingMovie.DirectorId)
            {
                var director = await _context.Directors.FindAsync(movie.DirectorId);
                if (director == null)
                {
                    director = new Director { Id = movie.DirectorId, Name = movie.Director.Name };
                    await _context.Directors.AddAsync(director);
                }
                existingMovie.DirectorId = movie.DirectorId;
            }

            // Update genre
            if (movie.GenreId != existingMovie.GenreId)
            {
                var genre = await _context.Genres.FindAsync(movie.GenreId);
                if (genre == null)
                {
                    genre = new Genre { Id = movie.GenreId, Name = movie.Genre.Name };
                    await _context.Genres.AddAsync(genre);
                }
                existingMovie.GenreId = movie.GenreId;
            }

            // Update reviews
            if (movie.Reviews != null && movie.Reviews.Any())
            {
                foreach (var review in movie.Reviews)
                {
                    if (review.Id == 0) // New review
                    {
                        review.MovieId = movie.Id;
                        _context.Reviews.Add(review);
                    }
                    else // Update existing review
                    {
                        var existingReview = await _context.Reviews.FindAsync(review.Id);
                        if (existingReview != null)
                        {
                            existingReview.Rating = review.Rating;
                            existingReview.Comment = review.Comment;
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Review with id {review.Id} not found.");
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
            return existingMovie;
        }
    }
}
