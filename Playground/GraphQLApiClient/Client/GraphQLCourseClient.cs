using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
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
    }
}
