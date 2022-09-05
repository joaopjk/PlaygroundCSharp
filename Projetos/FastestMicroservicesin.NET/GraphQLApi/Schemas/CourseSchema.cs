using System;
using GraphQL.Types;
using GraphQLApi.Queries;

namespace GraphQLApi.Schemas
{
  public class CourseSchema : Schema
  {
    public CourseSchema(ProQuery proQuery, IServiceProvider services) : base(services)
    {
      Query = proQuery;
    }
  }
}