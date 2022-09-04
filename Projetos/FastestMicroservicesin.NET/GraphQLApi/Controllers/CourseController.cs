using System.Threading.Tasks;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQLApi.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQLApi.Controllers
{
  [Route("graphql")]
  [ApiController]
  public class CourseController : ControllerBase
  {
    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
      _logger = logger;
    }

    [HttpGet("getcourses")]
    public async Task<string> GetCourse([FromQuery] string query)
    {
      _logger.LogInformation("");

      var schema = Schema.For(@"type Query {courses: [Course!] course (id : ID!) : Course}
                                enum PaymentType {FREE, PAID}
                                type Course {
                                  id: ID!,
                                  title: String!
                                  duration: Int
                                  level: String!
                                  instructor: String
                                  paymentType: PaymentType
                                  ratings: [Rating]
                                }
                                type Rating{
                                  id: ID!
                                  courseID: Int
                                  studentName: String
                                  starValue: Int
                                  review: String
                                }",
                                builder => builder.Types.Include<Query>());

      return await schema.ExecuteAsync(options => options.Query = query);
    }
  }
}