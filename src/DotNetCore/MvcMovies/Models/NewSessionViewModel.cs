using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Models
{
    public class NewSessionViewModel
    {
        [Required]
        public string SessionName { get; set; }
    }
}
