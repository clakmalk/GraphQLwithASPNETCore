using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMS.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
                context.Database.EnsureCreated();

                if (context.Students.Any())
                {
                    return; //Db has been created alreay
                }

                var students = new Student[]
                {
                new Student(){ Id=1, Name = "Cecilia Chapman",
                    Address = "711-2880 Nulla St.Mankato Mississippi 96522",
                    Email = "CeciliaChapman@ThinkAndLearn.com",
                    PhoneNumber = "(257) 563-7401"  },
                new Student(){  Id=2, Name = "Iris Watson",
                    Address = "P.O. Box 283 8562 Fusce Rd. Frederick Nebraska 20620",
                    Email = "IrisWatson@ThinkAndLearn.com",
                    PhoneNumber = "(372) 587-2335"  },
                new Student(){  Id=3,  Name = "Celeste Slater",
                    Address = "606-3727 Ullamcorper. Street Roseville NH 11523",
                    Email = "CelesteSlater@ThinkAndLearn.com",
                    PhoneNumber = "(786) 713-8616"  }
                };
            context.Set<Student>().AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course()
                {
                     Id=1,
                    Credits = 20,
                    Title = "Python Programming",
                    Description = "Learn Python Programming. This course will cover basics of python, advance Python tpics and Web API Platforms like Flask and DJango"
                },
                new Course()
                {
                     Id=2,
                    Credits = 20,
                    Title = "Data Strutures and Algorithms",
                    Description = "This course will cover basic and advance data structure use in Computer Programming."
                },
                new Course()
                {
                     Id=3,
                    Credits = 15,
                    Title = "Computer Hardware",
                    Description = "This course will cover basic and advance computer hardware topics"
                }
            };
            context.Set<Course>().AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollement[]
                {
                    new Enrollement()
                    {
                        Id = 1,
                        CourseId = 1, 
                        EndDate = DateTime.Now.AddMonths(4), 
                        StartDate = DateTime.Now, 
                        RegDate = DateTime.Now, 
                        Grade = "", 
                        StudentId = 1
                    },new Enrollement()
                    {
                        Id = 2,
                        CourseId = 1,
                        EndDate = DateTime.Now.AddMonths(4),
                        StartDate = DateTime.Now,
                        RegDate = DateTime.Now,
                        Grade = "",
                        StudentId = 2
                    },new Enrollement()
                    {
                        Id = 3,
                        CourseId = 2,
                        EndDate = DateTime.Now.AddMonths(4),
                        StartDate = DateTime.Now,
                        RegDate = DateTime.Now,
                        Grade = "",
                        StudentId = 3
                    },new Enrollement()
                    {
                        Id = 4,
                        CourseId = 2,
                        EndDate = DateTime.Now.AddMonths(4),
                        StartDate = DateTime.Now,
                        RegDate = DateTime.Now,
                        Grade = "",
                        StudentId = 1
                    },new Enrollement()
                    {
                        Id = 5,
                        CourseId = 3,
                        EndDate = DateTime.Now.AddMonths(4),
                        StartDate = DateTime.Now,
                        RegDate = DateTime.Now,
                        Grade = "",
                        StudentId = 1
                    }

                };
            context.Set<Enrollement>().AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
