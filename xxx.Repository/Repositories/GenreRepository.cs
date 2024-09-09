using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;

namespace xxx.Repository.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private DataContext _Context;
        public GenreRepository(DataContext Context)
        {
            _Context = Context;
        }
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _Context.Genres.ToListAsync();
        }
        public async Task<Genre> CreateGenre(Genre genre)
        {
            _Context.Genres.Add(genre);
            await _Context.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            var genre = await _Context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre != null)
            {
                _Context.Genres.Remove(genre);
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
