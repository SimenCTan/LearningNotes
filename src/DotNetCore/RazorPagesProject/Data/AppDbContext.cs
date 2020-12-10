using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data.Entities;

namespace RazorPagesProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Message> Messages { get; set; }

        public void Initialize()
        {
            Messages.AddRange(GetSeedingMessages());
            SaveChanges();
        }

        private static List<Message> GetSeedingMessages()
        {
            return new List<Message>()
            {
                new Message(){ Text = "You're standing on my scarf." },
                new Message(){ Text = "Would you like a jelly baby?" },
                new Message(){ Text = "To the rational mind, nothing is inexplicable; only unexplained." }
            };
        }
    }
}
