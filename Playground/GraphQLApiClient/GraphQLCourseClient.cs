using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace GraphQLApiClient
{
    public class GraphQLCourseClient
    {
        public static async Task GetCoursesViaHttpGet()
        {
            var graphQLClient = new GraphQLHttpClient(
                new Uri("https://localhost:7144/graphql/getcourses"),
                new NewtonsoftJsonSerializer());

            var qString = "{course (id : 1) { title, level, instructor, ratings { studentName , review } } }";
            //var qString = "{ courses { title, level, instructor, ratings { studentName , review } } }";
            var response = await graphQLClient.HttpClient.GetAsync(
                    @"https://localhost:7144/graphql/getcourses?query=" + qString);
            var result = response.Content.ReadAsStringAsync();
            Console.WriteLine(result.Result);
            Console.ReadKey();
        }
    }
}
