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
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;

        public DirectorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
           return await _context.Directors.ToListAsync();
        }
        public async Task<Director> GetDirectorById(int id)
        {
            var foundDirector = await _context.Directors.FirstOrDefaultAsync(x => x.Id == id);
            return foundDirector ?? throw new KeyNotFoundException($"Director with id {id} not found.");
        }
        public async Task<Director> CreateDirector(Director director)
        {
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<bool> DeleteDirector(int id)
        {
            var director = await _context.Directors.FirstOrDefaultAsync(x => x.Id == id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
