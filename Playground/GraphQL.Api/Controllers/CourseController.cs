using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GraphQL.Api.Data;
using GraphQL.SystemTextJson;
using GraphQL.Api.Queries;

namespace GraphQL.Api.Controllers
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
    }
}
