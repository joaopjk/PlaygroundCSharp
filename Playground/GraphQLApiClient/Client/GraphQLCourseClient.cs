using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQLApiClient.Data;
using System;
using System.Threading.Tasks;

namespace GraphQLApiClient.Https
{
    public class GraphQLCourseClient
    {
        public static async Task GetCoursesViaHttpGet()
        {
            var graphQLClient = new GraphQLHttpClient(
                    new Uri("https://localhost:44361/graphql/getcourses"), new SystemTextJsonSerializer());

            //mutiple courses
            var qString = "{ courses { title, level, instructor, ratings { studentName , review } } }";
            //single course
            //var qString = "{ course (id:1) { title, level, instructor } }";

            var response = await graphQLClient.HttpClient.GetAsync(@"https://localhost:44361/graphql/getcourses?query= " + qString);

            var result = response.Content.ReadAsStringAsync();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(result.Result);
            Console.ResetColor();
        }

        public static async Task GetCoursesViaHttpPost()
        {
            var graphQLClient = new GraphQLHttpClient(
                new Uri("https://localhost:5005/graphql/getcourses"), new SystemTextJsonSerializer());

            var qString = "{ courses { title, level, instructor, ratings { studentName , review } } }";
            var postRequest = new GraphQLRequest { Query = qString };

            var response = await graphQLClient.SendQueryAsync<CourseResponse>(postRequest);

            var courseList = response.Data.Courses;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(courseList);
            Console.ResetColor();
        }
    }
}
