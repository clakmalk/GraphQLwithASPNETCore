using GraphQL.Types;
using SMS.WebAPI.Core.Entities;
using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.EntityTypes
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType( ICourseRepository courseRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Student Id");
            Field(x => x.Address).Description("Student Address");
            Field(x => x.Email).Description("Student Email");
            Field(x => x.Name).Description("Student name");
            Field(x => x.PhoneNumber).Description("Student Phone number");
            Field<ListGraphType<CourseType>>("courses", resolve: context => courseRepository.GetStudentCourses(context.Source.Id).ToList());
        }
    }
}
