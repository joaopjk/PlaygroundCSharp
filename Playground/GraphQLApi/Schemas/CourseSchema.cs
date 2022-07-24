using GraphQL.Types;
using GraphQLApi.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLApi.Schemas
{
    public class CourseSchema : Schema
    {
        public CourseSchema(IServiceProvider services, ProQuery proQuery) : base(services)
        {
            Query = proQuery;
            //Query = services.GetRequiredService<ProQuery>();

        }
    }
}
