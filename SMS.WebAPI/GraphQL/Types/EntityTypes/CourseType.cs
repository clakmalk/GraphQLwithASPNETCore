using GraphQL.Types;
using SMS.WebAPI.Core.Entities;
using SMS.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.GraphQL.Types.EntityTypes
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType(ICourseRepository courseRepository)
        {
            Field(a => a.Id).Description("Course Id");
            Field(a => a.Description).Description("Course Description");
            Field(a => a.Title).Description("Course title");
        }
    }
}
