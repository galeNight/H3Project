using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;

namespace xxx.Repository.Models
{
    public class Movie : IMovie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public float DurationMinutes { get; set; }

        // Relation til Director
        public int DirectorId { get; set; }
        public Director ?Director { get; set; }

        // Relation til Genre
        public int GenreId { get; set; }
        public Genre ?Genre { get; set; }

        // En film kan have mange anmeldelser
        public ICollection<Review> Reviews { get; set; }
    }
}
