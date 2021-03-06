using GraphQL.Api.Data;
using GraphQL.Types;

namespace GraphQL.Api.Types
{
    public class RatingType : ObjectGraphType<Rating>
    {
        public RatingType()
        {
            Name = "Rating";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Rating ID.");
            Field(x => x.CourseId);
            Field(x => x.StudentName);
            Field(x => x.Review);
            Field(x => x.StarValue);
        }
    }
}
