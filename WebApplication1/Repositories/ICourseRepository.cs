using SMS.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        List<Course> GetStudentCourses(int studentId);
    }
}
