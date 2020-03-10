using GraphQL.Types;
using SMS.WebAPI.GraphQL.Types.EntityTypes;
using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.RootTypes
{
    public class Query : ObjectGraphType
    {
        public Query(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            Field<ListGraphType<StudentType>>(
                "students",
                resolve: context => studentRepository.GetStudents());
            Field<StudentType>("student", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Student id" }
                ), resolve: context => studentRepository.GetStudent(context.GetArgument<int>("id")));
            Field<ListGraphType<CourseType>>(
                "courses",
                resolve: context => courseRepository.GetCourses());
            Field<CourseType>(
                "course",
                arguments: new QueryArguments(new QueryArgument <NonNullGraphType<IntGraphType>> { Name = "id", Description = "Course Id" }),
                resolve: context => courseRepository.GetCourse(context.GetArgument<int>("id")));
        }

       
    }
}
