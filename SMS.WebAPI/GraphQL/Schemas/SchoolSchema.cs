using GraphQL;
using GraphQL.Types;
using SMS.WebAPI.GraphQL.Types.RootTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Schemas
{
    public class SchoolSchema :Schema
    {
        public SchoolSchema(IDependencyResolver resolver) 
            : base(resolver)
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
            Subscription = resolver.Resolve<Subscribe>();
        }
    }
}
