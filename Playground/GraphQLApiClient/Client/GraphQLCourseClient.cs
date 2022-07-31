using GraphQL;
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

        public static async Task GetCoursesViaHttpPost()
        {
            try
            {
                var graphQLClient = new GraphQLHttpClient(
                    new Uri("https://localhost:5005/graphql/getcoursesWithGraphQLClient"), new SystemTextJsonSerializer());

                //var qString = "{ courses { title, level, instructor, ratings { studentName , review } } }";
                var qString = "query GetCourse($paymentType!: PaymenyType, $showRating: Boolean, $skipName: Boolean)" +
                    "{ courses (paymentType:$paymentType){title, level, instructor, paymentType," +
                    " rating @include(if: $showRating){studentName @skip(if: $skipName),review }}}";
                var postRequest = new GraphQLRequest { Query = qString
                ,Variables =  new {paymentType = true, showRating = true, skipName = true }
                };

                var response = await graphQLClient.SendQueryAsync<object>(postRequest);

                var courseList = response.Data;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(courseList);
                Console.ResetColor();

                //var httpClient = new HttpClient();
                //var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://localhost:5005/graphql/getcourses?query={qString}"));
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //using var response = await httpClient.SendAsync(request);
                //var result = response.Content.ReadAsStringAsync();

                //Console.ForegroundColor = ConsoleColor.Magenta;
                //Console.WriteLine(JsonSerializer.Deserialize<object>(result.Result));
                //Console.ResetColor();
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
