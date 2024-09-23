using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Models;

namespace xxx.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGrenreById(int id);
        Task<Genre> CreateGenre(Genre genre);
        Task<bool> DeleteGenre(int id);
    }
}
