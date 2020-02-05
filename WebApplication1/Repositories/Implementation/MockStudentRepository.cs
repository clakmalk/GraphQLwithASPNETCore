using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.WebAPI.Core.Entities;

namespace SMS.WebAPI.Repositories.Implementation
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _students = new List<Student>();
        public MockStudentRepository()

        {
            _students.Add(new Student()
            {
                Id = 1,
                 Name = "Kenul Amarasinghe", 
                 Address = "7/2/8, Highway Rd, Homagama",
                 Email = "Kenul@ThinkAndLearn.com",
                 PhoneNumber = "0094777234234"
            });
            _students.Add(new Student()
            {
                Id = 1,
                Name = "Akain Mark",
                Address = "345, Bernard RD, Maharagama",
                Email = "Kenul@ThinkAndLearn.com",
                PhoneNumber = "0094777234234"
            });
            _students.Add(new Student()
            {
                Id = 1,
                Name = "Shakila Perera",
                Address = "34, Gall Rd, Marata",
                Email = "Kenul@ThinkAndLearn.com",
                PhoneNumber = "0094777234234"
            });
        }
        public List<Student> GetStudents()
        {
            return _students;
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }
        

        public Student UpdateStudent(Student student)
        {
            var studentToUpdate = _students.Where(a => a.Id == student.Id).FirstOrDefault();
            if (studentToUpdate!= null)
            {
                studentToUpdate.Address = student.Address;
                studentToUpdate.Email = student.Email;
                studentToUpdate.Name = student.Name;
                studentToUpdate.PhoneNumber = student.PhoneNumber;
            }else
            {
                throw new Exception("Could not find the student provided");
            }
            return studentToUpdate;
        }

        public Student DeleteStudent(int studentId)
        {
            var studentToDelete = _students.Where(a => a.Id == studentId).FirstOrDefault();
            if (studentToDelete != null)
            {
                _students.Remove(studentToDelete);
            }
            else
            {
                throw new Exception("Could not find the student provided");
            }
            return studentToDelete;
        }

        public Student GetStudent(int studentId)
        {
            return _students.Where(a => a.Id == studentId).FirstOrDefault();
        }
    }
}
