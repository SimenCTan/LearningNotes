using RazorPagesProject.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesProject.Data.Entities;

namespace RazorPagesProject.Tests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AppDbContext db)
        {
            db.Messages.AddRange(GetSeedingMessages());
            db.Students.AddRange(GetStudents());
            db.Instructors.AddRange(GetInstructors());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(AppDbContext db)
        {
            db.Messages.RemoveRange(db.Messages);
            InitializeDbForTests(db);
        }

        public static List<Message> GetSeedingMessages()
        {
            return new List<Message>()
            {
                new Message(){ Text = "TEST RECORD: You're standing on my scarf." },
                new Message(){ Text = "TEST RECORD: Would you like a jelly baby?" },
                new Message(){ Text = "TEST RECORD: To the rational mind, " +
                    "nothing is inexplicable; only unexplained." }
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
