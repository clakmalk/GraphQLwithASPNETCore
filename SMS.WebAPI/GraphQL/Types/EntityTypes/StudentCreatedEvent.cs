using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.EntityTypes
{
    public class StudentCreatedEvent : StudentType
    {
        public StudentCreatedEvent(IStudentRepository studentRepository, ICourseRepository courseRepository)
            :base(studentRepository, courseRepository)
        {

        }
    }
}
