using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Models;

namespace xxx.Repository.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllDirectors();
        Task<Director> GetDirectorById(int id);
        Task<Director> CreateDirector(Director director);
        Task<bool> DeleteDirector(int id);
    }
}
