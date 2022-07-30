using GraphQL.Api.Data;
using GraphQL.Api.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Api.Queries
{
    public class ProQuery : ObjectGraphType
    {
        public ProQuery(CourseDbContext courseDbContext)
        {
            Field<ListGraphType<CourseType>>("courses",
                    resolve: context =>
                    {
                        return courseDbContext.Course
                                              .Include(c => c.Ratings)
                                              .AsNoTracking()
                                              .ToListAsync();
                    }
                );
        }
    }
}
