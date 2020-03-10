using GraphQL.Resolvers;
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
    public class Subscribe :ObjectGraphType
    {
        public Subscribe(IStudentRepository studentRepository)
        {
            this.Name = "Subscription";
            this.Description = "The subscription type, represents all updates can be pushed to the client in real time over web sockets.";
            this.AddField(
                new EventStreamFieldType()
                {
                    Name = "studentCreated",
                    Description = "Subscribe to student created events.",
                    Type = typeof(StudentCreatedEvent),
                    Resolver = new FuncFieldResolver<Student>(context =>
                                      context.Source as Student),
                    Subscriber = new EventStreamResolver<Student>(context =>
                    {
                        return studentRepository.WhenStudentCreated;
                    }),
                });

        }
    }
}
