using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.EFConfigurationProvider
{
    public class EFConfigurationContext:DbContext
    {
        public EFConfigurationContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<EFConfigurationValue> Values { get; set; }
    }
}
