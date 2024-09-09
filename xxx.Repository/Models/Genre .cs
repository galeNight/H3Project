using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xxx.Repository.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // En genre kan have mange film
        public ICollection<Movie> Movies { get; set; }
    }
}
