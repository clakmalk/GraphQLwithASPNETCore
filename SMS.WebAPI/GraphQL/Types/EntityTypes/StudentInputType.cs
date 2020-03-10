using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.EntityTypes
{
    public class StudentInputType : InputObjectGraphType
    {
       public StudentInputType()
        {
            Name = "studentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
            Field<NonNullGraphType<StringGraphType>>("phoneNumber");
            Field<NonNullGraphType<StringGraphType>>("email");
        }
    }
}
