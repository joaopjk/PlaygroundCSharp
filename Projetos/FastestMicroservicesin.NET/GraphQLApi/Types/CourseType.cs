using GraphQL.Types;
using GraphQLApi.Data.Entities;

namespace GraphQLApi.Types
{
  public class CourseType : ObjectGraphType<Course>
  {
    public CourseType()
    {
      Name = "Course";
      Description = "Represents Course data";
      Field("id", _ => _.Id, nullable: false, type: typeof(IdGraphType)).Description("Course Id");
      Field(_ => _.Title, type: typeof(StringGraphType)).Description("Course Title");
      Field(_ => _.Duration, type: typeof(StringGraphType)).Description("Course duration");
      Field(_ => _.Level);
      Field(_ => _.Instructor);
      Field(_ => _.PaymentType, type: typeof(PaymentTypeEnum));
      Field<ListGraphType<RatingType>>("Ratings");
    }
  }
}