using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.WebAPI.Core.Entities;

namespace SMS.WebAPI.Repositories.Implementation
{
    public class MockCouseRepository : ICourseRepository
    {
        private List<Course> _courses = new List<Course>();
        private List<Enrollement> _studentCourses = new List<Enrollement>();

        public MockCouseRepository()
        {
            _courses.Add(new Course()
            {
                Id = 1,
                Title = "Python Programming",
                Description = "Learn Python Programming. This course will cover basics of python, advance Python tpics and Web API Platforms like Flask and DJango"
            });
            _courses.Add(new Course()
            {
                Id = 2,
                Title = "Data Strutures and Algorithms",
                Description = "This course will cover basic and advance data structure use in Computer Programming."
            });
            _courses.Add(new Course()
            {
                Id = 3,
                Title = "Computer Hardware",
                Description = "This course will cover basic and advance computer hardware topics"
            });

            _studentCourses.Add(new Enrollement()
            {
                Id = 1, CourseId = 1, 
                StudentId = 1, 
                RegDate = DateTime.Now, 
                StartDate = DateTime.Now, 
                EndDate = DateTime.Now.AddMonths(10)
            });
            _studentCourses.Add(new Enrollement()
            {
                Id = 2,
                CourseId = 1,
                StudentId = 2,
                RegDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(10)
            });

            _studentCourses.Add(new Enrollement()
            {
                Id = 2,
                CourseId = 2,
                StudentId = 2,
                RegDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(10)
            });

            _studentCourses.Add(new Enrollement()
            {
                Id = 3,
                CourseId = 2,
                StudentId = 3,
                RegDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(10)
            });
        }

        public Course GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses()
        {
            return _courses;
        }

        public List<Student> GetCourseStudents(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            return (from course in _courses
                   join studentCourse in _studentCourses
                   on course.Id equals studentCourse.CourseId where studentCourse.StudentId == studentId
                   select course).ToList();
        }
    }
}
