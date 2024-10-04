using System;
using System.ComponentModel.DataAnnotations;

namespace xxx.Repository.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Range(1,10)]
        public int Rating { get; set; } // Skala fra 1-5
        public string Comment { get; set; }

        // Relation til Movie
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
