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
        public async Task GetMovieById_ThrowsKeyNotFoundException_WhenIdIsInvalid()
        {
            // Arrange
            var invalidMovieId = 999; // An ID that does not exist

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _movieRepository.GetMovieById(invalidMovieId));
            Assert.Equal($"Movie with id {invalidMovieId} not found.", exception.Message);
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
        
    }
}
