using GraphQL.Types;
using GraphQLApi.Data;
using GraphQLApi.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Queries
{
  public class ProQuery : ObjectGraphType
  {
    public ProQuery(CourseDbContext courseDbContext)
    {
      FieldAsync<ListGraphType<CourseType>>("courses",
          resolve: async _ =>
          {
            return await courseDbContext.Course
                    .Include(r => r.Ratings)
                    .AsNoTracking()
                    .ToListAsync();
          }
      );
    }
  }
}