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

        public DbSet<Person> People { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }



        public void Initialize()
        {
            Messages.AddRange(GetSeedingMessages());
            Students.AddRange(GetStudents());
            Instructors.AddRange(GetInstructors());
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

        private static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student{ FirstMidName="test",LastName="student",EnrollmentDate=DateTime.Now},
                new Student{ FirstMidName="test1",LastName="student1",EnrollmentDate=DateTime.Now},
                new Student{ FirstMidName="test2",LastName="student2",EnrollmentDate=DateTime.Now}
            };
        }

        private static List<Instructor> GetInstructors()
        {
            return new List<Instructor>()
            {
                new Instructor{ FirstMidName="test",LastName="Instructor",HireDate=DateTime.Now},
                new Instructor{ FirstMidName="test1",LastName="Instructor1",HireDate=DateTime.Now},
                new Instructor{ FirstMidName="test2",LastName="Instructor2",HireDate=DateTime.Now}
            };
        }
    }
}
