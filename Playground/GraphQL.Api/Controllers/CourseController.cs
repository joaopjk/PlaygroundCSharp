using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GraphQL.Api.Data;
using GraphQL.SystemTextJson;
using GraphQL.Api.Queries;
using System.Linq;

namespace GraphQL.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ISchema _schema;
        public CourseController(ILogger<CourseController> logger, ISchema schema)
        {
            _logger = logger;
            _schema = schema;
        }

        [HttpGet]
        [Route("getcourses")]
        public async Task<string> GetCourse([FromQuery] string query)
        {
            var schema = Schema.For(@"
                    type Query {
                                   courses : [Course!]  
                                   course (id : ID!) : Course
                                                                                                            
                                 }
                    enum PaymentType {
                                        FREE ,
                                        PAID
                                  }
                    type Course {
                                    title: String!
                                    duration: Int
                                    level : String!
                                    instructor: String
                                    paymentType : PaymentType
                                    ratings : [Rating]
                                }
                    type Rating
                                {   
                                    studentName : String
                                    stars : Int
                                    review : String
                                }", builder =>
                                {
                                    //builder.Types.Include<Course>();
                                    builder.Types.Include<Query>();

                                });

            var json = await schema.ExecuteAsync(options =>
            {
                options.Query = query;
            });

            return json;
        }

        [HttpPost]
        [Route("getcourses")]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await new DocumentExecuter()
                .ExecuteAsync(_ =>
                {
                    _.Schema = _schema;
                    _.Query = query.Query;
                });

            if (result.Errors?.Count > 0)
            {
                _logger.Log(LogLevel.Error, $"Post - getcourses : " + string.Join('|', result.Errors.Select(x => x.Message)));
            }

            return Ok(result.Data);
        }
    }
}
