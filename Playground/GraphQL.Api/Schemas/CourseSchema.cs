using GraphQL.Api.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.Api.Schemas
{
    public class CourseSchema : Schema
    {
        public CourseSchema(ProQuery proQuery, IServiceProvider services) : base(services)
        {
            //Query = proQuery;
            Query = services.GetRequiredService<ProQuery>();
        }
    }
}
