using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
