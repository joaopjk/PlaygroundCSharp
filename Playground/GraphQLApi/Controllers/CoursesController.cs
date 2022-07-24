using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using GraphQL.NewtonsoftJson;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GraphQLApi.Data;
using GraphQLApi.Queries;
using GraphQL;

namespace GraphQLApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ISchema _schema;

        public CoursesController(ILogger<CoursesController> logger, ISchema schema)
        {
            _logger = logger;
            _schema = schema;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await new DocumentExecuter()
                .ExecuteAsync(exc =>
                {
                    exc.Schema = _schema;
                    exc.Query = query.Query;
                });

            if (result.Errors?.Count > 0)
                return BadRequest(result.Errors);
            return Ok(result);
        }
    }
}
