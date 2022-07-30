using GraphQL.Api.Data;
using GraphQL.Api.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQL.Api.Queries
{
#pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
    public class ProQuery : ObjectGraphType
    {
        public ProQuery(CourseDbContext courseDbContext)
        {
            Field<ListGraphType<CourseType>>("courses",
                    arguments: new QueryArguments
                    (
                        new QueryArgument<StringGraphType> { Name = "instructor", Description = "course instructor" },
                        //new QueryArgument<NonNullGraphType<PaymentTypeEnum>> { Name = "paymentType" , DefaultValue = 1},
                        new QueryArgument<PaymentTypeEnum?> { Name = "paymentType" },
                        new QueryArgument<IntGraphType> { Name = "id", Description = "course id" },
                        new QueryArgument<IntGraphType> { Name = "starValue", Description = "star value of the rating" }
                    ),
                    resolve: context =>
                    {
                        var instructor = context.GetArgument<string>("instructor");
                        var paymentType = context.GetArgument<PaymentType?>("paymentType");
                        var id = context.GetArgument<int?>("id");
                        var starValue = context.GetArgument<int?>("starValue");

                        var courses = courseDbContext.Course
                                                    .Where(_ => string.IsNullOrEmpty(instructor) == true || _.Instructor == instructor
                                                    && paymentType == null || _.PaymentType == paymentType
                                                    && id == null || _.Id == id)
                                                    .Include(_ => _.Ratings.Where(_ => (starValue == null || _.StarValue == starValue)));
                        return courses;
                    }
                );
        }
    }
#pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
}
