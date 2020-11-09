using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var movieContext = new MovieDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>());
            if (movieContext.Movie.Any())
            {
                return;
            }
            var movies = new List<Movie>
            {
                new Movie { ReleaseDate = DateTime.Now, Genre = "Ghostbusters", Price = 7.90M, Title = "MvcMovie", Rating = "Mvc" },
                new Movie { ReleaseDate = DateTime.Now, Genre = "Ghostbusters", Price = 8.90M, Title = "MvcMovie", Rating = "Mvc" }
            };
            movieContext.Movie.AddRange(movies);
            movieContext.SaveChanges();
        }
    }
}
