using GraphQLApiClient.Https;
using System.Threading.Tasks;

namespace GraphQLApiClient
{
    internal class Program
    {
        static void Main(string[] _)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            //await GraphQLCourseClient.GetCoursesViaHttpGet();
            await GraphQLCourseClient.GetCoursesViaHttpPost();
        }
    }
}
