using GraphQL;
using GraphQL.Types;
using SMS.WebAPI.Core.Entities;
using SMS.WebAPI.GraphQL.Types.EntityTypes;
using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.RootTypes
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(IStudentRepository studentReposiroty, ICourseRepository courseRepository)
        {
            Field<StudentType>(
                "createStudent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StudentInputType>> { Name = "student" }),

                resolve: context =>
                {
                    var student = context.GetArgument<Student>("student");
                    return studentReposiroty.AddStudent(student);
                });
            Field<StudentType>(
                "updateStudent",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StudentInputType>> { Name = "student" },
                        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "studentId" }),
                resolve: context =>
                {
                    var student = context.GetArgument<Student>("student");
                    var studentId = context.GetArgument<int>("studentId");
                    var dbStudent = studentReposiroty.GetStudent(studentId);
                    if (dbStudent != null)
                    {
                        return studentReposiroty.UpdateStudent(student, dbStudent);
                    }else
                    {
                        context.Errors.Add(new ExecutionError("Could not find the Student in database"));
                        return null;
                    }
                });
            Field<StudentType>(
                "deleteStudent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "studentId" }),
                resolve: context =>
                {
                    var studentId = context.GetArgument<int>("studentId");
                    return studentReposiroty.DeleteStudent(studentId);
                });
            
        }
    }
}
