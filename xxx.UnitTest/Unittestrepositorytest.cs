using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;
using xxx.Repository.Repositories;

namespace xxx.UnitTest
{
    public class Unittestrepositorytest
    {
        private readonly GenreRepository _genreRepository;
        private readonly DirectorRepository _directorRepository;
        private readonly DataContext _context;
        private readonly MovieRepository _movieRepository;
        private readonly ReviewRepository _reviewRepository;

        public Unittestrepositorytest()
        {
            // Use an in-memory database for testing
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new DataContext(options);
            _directorRepository = new DirectorRepository(_context);
            _genreRepository = new GenreRepository(_context);
            _movieRepository = new MovieRepository(_context);
            _reviewRepository = new ReviewRepository(_context);
            _context.Database.EnsureDeleted();
        }
        //director true and false
        [Fact]
        public async Task GetDirectorById_ReturnsDirector_WhenIdIsValid()
        {
            // Arrange
            var directorId = 1;
            var director = new Director { Id = directorId, Name = "Steven Spielberg" };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _directorRepository.GetDirectorById(directorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(directorId, result.Id);
        }
        [Fact]
        public async Task GetDirectorById_ThrowsKeyNotFoundException_WhenIdIsInvalid()
        {
            // Arrange
            var invalidDirectorId = 999; // An ID that does not exist

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _directorRepository.GetDirectorById(invalidDirectorId));
            Assert.Equal($"Director with id {invalidDirectorId} not found.", exception.Message);
        }
        [Fact]
        public async Task GetAllDirectors_ReturnsAllDirectors()
        {
            // Arrange
            var directors = new List<Director>
        {
            new Director { Id = 1, Name = "Steven Spielberg" },
            new Director { Id = 2, Name = "Christopher Nolan" }
        };
            _context.Directors.AddRange(directors);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _directorRepository.GetAllDirectors();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task DeleteDirector_RemovesDirector_WhenIdIsValid()
        {
            // Arrange
            var directorId = 1;
            var director = new Director { Id = directorId, Name = "Steven Spielberg" };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _directorRepository.DeleteDirector(directorId);

            // Assert
            Assert.True(result);
            Assert.Null(await _context.Directors.FirstOrDefaultAsync(x => x.Id == directorId));
        }
        [Fact]
        public async Task DeleteDirector_ReturnsFalse_WhenIdIsInvalid()
        {
            // Arrange
            var invalidDirectorId = 999; // An ID that does not exist

            // Act
            var result = await _directorRepository.DeleteDirector(invalidDirectorId);

            // Assert
            Assert.False(result);
        }
        //genre true and false
        [Fact]
        public async Task GetGenreById_ReturnsGenre_WhenIdIsValid()
        {
            // Arrange
            var genreId = 1;
            var genre = new Genre { Id = genreId, Name = "Action" };
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _genreRepository.GetGrenreById(genreId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(genreId, result.Id);
        }
        [Fact]
        public async Task GetGenreById_ThrowsKeyNotFoundException_WhenIdIsInvalid()
        {
            // Arrange
            var invalidGenreId = 999; // An ID that does not exist

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _genreRepository.GetGrenreById(invalidGenreId));
            Assert.Equal($"Genre with id {invalidGenreId} not found.", exception.Message);
        }
        [Fact]
        public async Task GetAllGenres_ReturnsAllGenres()
        {
            // Arrange
            var genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" }
        };
            _context.Genres.AddRange(genres);
            await _context.SaveChangesAsync();

            // Act
            var result = await _genreRepository.GetAllGenres();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task DeleteGenre_RemovesGenre_WhenIdIsValid()
        {
            // Arrange
            var genreId = 1;
            var genre = new Genre { Id = genreId, Name = "Action" };
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            // Act
            var result = await _genreRepository.DeleteGenre(genreId);

            // Assert
            Assert.True(result);
            Assert.Null(await _context.Genres.FirstOrDefaultAsync(x => x.Id == genreId));
        }

        [Fact]
        public async Task DeleteGenre_ReturnsFalse_WhenIdIsInvalid()
        {
            // Arrange
            var invalidGenreId = 999;

            // Act
            var result = await _genreRepository.DeleteGenre(invalidGenreId);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public async Task CreateGenre_AddsGenre()
        {
            // Arrange
            var genre = new Genre { Id = 1, Name = "Action" };

            // Act
            var result = await _genreRepository.CreateGenre(genre);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(genre.Id, result.Id);
            Assert.Equal(genre.Name, result.Name);
        }
        //movie true and false
        [Fact]
        public async Task GetMovieById_ReturnsMovie_WhenIdIsValid()
        {
            // Arrange
            var movieId = 1;
            var movie = new Movie { Id = movieId, Title = "Jurassic Park", DurationMinutes = 127 };
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _movieRepository.GetMovieById(movieId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movieId, result.Id);
        }
        [Fact]
        public async Task GetMovieById_null_WhenIdIsInvalid()
        {
            // Arrange
            var invalidMovieId = 999; // An ID that does not exist

            // Act
            var result = await _movieRepository.GetMovieById(invalidMovieId);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task CreateMovie_AddsMovie()
        {
            // Arrange
            var movie = new Movie { Id = 1, Title = "Inception", DurationMinutes = 148, DirectorId = 1, GenreId = 1 };

            // Act
            var result = await _movieRepository.CreateMovie(movie);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movie.Id, result.Id);
            Assert.Equal(movie.Title, result.Title);
        }
        [Fact]
        public async Task GetAllMovies_ReturnsAllMovies()
        {
            // Arrange
            var movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", DurationMinutes = 148, DirectorId = 1, GenreId = 1 },
            new Movie { Id = 2, Title = "The Matrix", DurationMinutes = 136, DirectorId = 2, GenreId = 2 }
        };
            _context.Movies.AddRange(movies);
            await _context.SaveChangesAsync();

            // Act
            var result = await _movieRepository.GetAllMovies();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task DeleteById_RemovesMovie_WhenIdIsValid()
        {
            // Arrange
            var movieId = 1;
            var movie = new Movie { Id = movieId, Title = "Inception", DurationMinutes = 148, DirectorId = 1, GenreId = 1 };
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // Act
            var result = await _movieRepository.DeleteById(movieId);

            // Assert
            Assert.True(result);
            Assert.Null(await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId));
        }
        [Fact]
        public async Task DeleteById_ReturnsFalse_WhenIdIsInvalid()
        {
            // Arrange
            var invalidMovieId = 999;

            // Act
            var result = await _movieRepository.DeleteById(invalidMovieId);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public async Task UpdateMovie_UpdatesMovieDetails()
        {
            // Arrange
            var movieId = 1;
            var movie = new Movie { Id = movieId, Title = "Inception", DurationMinutes = 148, DirectorId = 1, GenreId = 1 };
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            var updatedMovie = new Movie { Id = movieId, Title = "Inception Updated", DurationMinutes = 150, DirectorId = 1, GenreId = 1 };

            // Act
            var result = await _movieRepository.UpdateMovie(updatedMovie);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedMovie.Title, result.Title);
            Assert.Equal(updatedMovie.DurationMinutes, result.DurationMinutes);
        }
        [Fact]
        public async Task UpdateMovie_null_WhenIdIsInvalid()
        {
            // Arrange
            var invalidMovieId = 999;
            var movie = new Movie { Id = invalidMovieId, Title = "Inception", DurationMinutes = 148, DirectorId = 1, GenreId = 1 };

            // Act
            var result = await _movieRepository.UpdateMovie(movie);

            //Assert
            Assert.Null(result);
        }
        //review true and false
        [Fact]
        public async Task GetReviewById_ReturnsReview_WhenIdIsValid()
        {
            // Arrange
            var reviewId = 1;
            var review = new Review { Id = reviewId, MovieId = 1, Rating = 5, Comment = "Great movie!" };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(); // Ensure the context is saved

            // Act
            var result = await _reviewRepository.GetReviewById(reviewId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reviewId, result.Id);
        }
        [Fact]
        public async Task GetReviewById_ThrowsKeyNotFoundException_WhenIdIsInvalid()
        {
            // Arrange
            var invalidReviewId = 999; // An ID that does not exist

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _reviewRepository.GetReviewById(invalidReviewId));
            Assert.Equal($"Review with id {invalidReviewId} not found.", exception.Message);
        }
        [Fact]
        public async Task GetAllReviews_ReturnsAllReviews()
        {
            // Arrange
            var reviews = new List<Review>
        {
            new Review { Id = 1, Rating = 8, Comment = "Great movie!", MovieId = 1 },
            new Review { Id = 2, Rating = 5, Comment = "It was okay.", MovieId = 2 }
        };
            _context.Reviews.AddRange(reviews);
            await _context.SaveChangesAsync();

            // Act
            var result = await _reviewRepository.GetAllReviews();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task CreateReview_AddsReview()
        {
            // Arrange
            var review = new Review { Id = 1, Rating = 8, Comment = "Great movie!", MovieId = 1 };

            // Act
            var result = await _reviewRepository.CreateReview(review);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(review.Id, result.Id);
            Assert.Equal(review.Rating, result.Rating);
            Assert.Equal(review.Comment, result.Comment);
        }
        [Fact]
        public async Task DeleteReview_RemovesReview_WhenIdIsValid()
        {
            // Arrange
            var reviewId = 1;
            var review = new Review { Id = reviewId, Rating = 8, Comment = "Great movie!", MovieId = 1 };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            // Act
            var result = await _reviewRepository.DeleteReview(reviewId);

            // Assert
            Assert.True(result);
            Assert.Null(await _context.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId));
        }
        [Fact]
        public async Task DeleteReview_ReturnsFalse_WhenIdIsInvalid()
        {
            // Arrange
            var invalidReviewId = 999;

            // Act
            var result = await _reviewRepository.DeleteReview(invalidReviewId);

            // Assert
            Assert.False(result);
        }
    }
}
