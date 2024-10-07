using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xxx.Repository.Interfaces
{
    public interface IMovie
    {
        int Id { get; set; }
        string Title { get; set; }
        int DurationMinutes { get; set; }
    }
}
