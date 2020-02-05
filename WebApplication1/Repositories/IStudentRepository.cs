using SMS.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();
        public Student GetStudent(int studentId);
        public Student AddStudent(Student student);
        public Student UpdateStudent(Student student);
        public Student DeleteStudent(int studentId);

    }
}
