using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Models;

namespace xxx.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>>? GetAllMovies();
        Task<Movie>? GetMovieById(int id);
        Task<Movie>? CreateMovie(Movie movie);
        Task<bool> DeleteById(int id);
        Task<Movie> UpdateMovie(Movie movie);

        //Task<IEnumerable<Director>> GetAllDirectors();
        //Task<IEnumerable<Genre>> GetAllGenres();
        //Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId);
    }
}
