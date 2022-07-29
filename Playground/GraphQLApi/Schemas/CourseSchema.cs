using GraphQL.Types;
using GraphQLApi.Queries;

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
