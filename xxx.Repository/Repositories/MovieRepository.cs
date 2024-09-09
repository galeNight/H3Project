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
    }
}
