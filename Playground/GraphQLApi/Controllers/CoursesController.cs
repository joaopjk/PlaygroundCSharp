using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using GraphQL.NewtonsoftJson;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GraphQLApi.Data;
using GraphQLApi.Queries;

namespace GraphQLApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ILogger<CoursesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getcourses")]
        public async Task<string> GetCourses([FromQuery] string query)
        {
            var schema = Schema.For(@"type Query
                                                { 
                                                 courses:[Course!]
                                                 course(id:ID!):Course
                                                }
                                      enum PaymentType { FREE, PAID }
                                      type Course {
                                                    id: ID!
                                                    title: String!
                                                    duration: Int
                                                    level: String!
                                                    instructor: String!
                                                    paymenteType: PaymentType
                                                    ratings: [Rating]
                                                  }
                                      type Rating{
                                                    id: ID!
                                                    courseId: Int
                                                    studentName: String!
                                                    stars: Int
                                                    review: String
                                                 }", builder =>
                                    {
                                        builder.Types.Include<Course>();
                                        builder.Types.Include<Query>();
                                    });
            var json = await schema.ExecuteAsync(options =>
            {
                options.Query = query;
            });

            return json;
        }
    }
}
