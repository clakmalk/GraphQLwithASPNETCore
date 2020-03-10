using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using SMS.WebAPI.Core.Entities;
using SMS.WebAPI.Data;

namespace SMS.WebAPI.Repositories.Implementation
{
    public class SqlServerStudentRepository : IStudentRepository
    {
        private SchoolDbContext _dbContext;
        private readonly Subject<Student> whenStudentCreated;

        public SqlServerStudentRepository() => this.whenStudentCreated = new Subject<Student>();

        public IObservable<Student> WhenStudentCreated => this.whenStudentCreated.AsObservable();

        public SqlServerStudentRepository(SchoolDbContext context)
        {
            _dbContext = context;
        }
        public Student AddStudent(Student student)
        {
            _dbContext.Set<Student>().Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int studentId)
        {
            var student = _dbContext.Set<Student>().Find(studentId);
            if (student != null)
            {
                _dbContext.Set<Student>().Remove(student);
                _dbContext.SaveChanges();
                return student;
            }else

            {
                throw new Exception("Student cound not found");
            }
        }

        public Student GetStudent(int studentId)
        {
            return _dbContext.Set<Student>().Find(studentId);
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Set<Student>().ToList();
        }

        public Student UpdateStudent(Student newStudent, Student dbStudent)
        {
            dbStudent.Address = newStudent.Address;
            dbStudent.Email = newStudent.Email;
            dbStudent.Name = newStudent.Name;
            dbStudent.PhoneNumber = newStudent.PhoneNumber;
            _dbContext.SaveChanges();
            return dbStudent;
        }
    }
}
