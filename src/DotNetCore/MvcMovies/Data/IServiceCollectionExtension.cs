using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Data
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddMovieDbContextService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQL"));
                options.EnableSensitiveDataLogging(Debugger.IsAttached);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });
            return services;
        }
    }
}
