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
            Field<ListGraphType<CourseType>>("courses",
                resolve: context =>
                {
                    var courses = courseDbContext.Course
                                                .Include(c => c.Ratings)
                                                .AsNoTracking()
                                                .ToListAsync();
                    return courses;
                });
        }
    }
}
