using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.WebAPI.Core.Entities;
using SMS.WebAPI.Data;

namespace SMS.WebAPI.Repositories.Implementation
{
    public class SqlServerCourseRepository : ICourseRepository
    {
        private SchoolDbContext _dbContext;
        public SqlServerCourseRepository(SchoolDbContext context)
        {
            _dbContext = context;
        }

        public Course GetCourse(int courseId)
        {
            var course = _dbContext.Coureses.Find(courseId);
            if (course == null)
            {
                throw new Exception("Could not find the course");
            }
            return course;
        }

        public List<Course> GetCourses()
        {
            return _dbContext.Coureses.ToList();
        }

        public List<Student> GetCourseStudents(int courseId)
        {
            var students = (from st in _dbContext.Students
                            join e in _dbContext.Enrollements on st.Id equals e.StudentId
                            where e.CourseId == courseId
                            select st);
            return students.ToList();
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            var courses = (from c in _dbContext.Coureses
                           join e in _dbContext.Enrollements on c.Id equals e.CourseId
                           where e.StudentId == studentId
                           select c);
            return courses.ToList();
        }
    }
}
