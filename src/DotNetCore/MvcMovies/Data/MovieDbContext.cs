using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvcMovies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
