using GraphQL.Types;
using SMS.WebAPI.GraphQL.Types.EntityTypes;
using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.RootTypes
{
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery(IStudentRepository studentRepository)
        {
            Field<ListGraphType<StudentType>>(
                "students",
                resolve: context => studentRepository.GetStudents());
            Field<ListGraphType<CourseType>>("student", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Student id" }
                ), resolve: context => studentRepository.GetStudent(context.GetArgument<int>("id")));
        }
    }
}
