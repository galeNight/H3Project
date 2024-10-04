using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using xxx.Repository.Interfaces;

namespace xxx.Repository.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // En instruktør kan have mange film
        public ICollection<Movie>? Movies { get; set; }
    }
}
