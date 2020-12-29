using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthChecksSample.Data
{
    public class HealthCheckDbContext:DbContext
    {
        public HealthCheckDbContext(DbContextOptions<HealthCheckDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
