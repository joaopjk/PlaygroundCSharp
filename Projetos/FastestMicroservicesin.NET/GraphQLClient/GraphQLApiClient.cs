using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace GraphQLClient
{
  public static class GraphQLApiClient
  {
    private const string UriString = "http://localhost:5006/graphql";

    public static async Task GetCoursesViaHttpGet()
    {
      GraphQLHttpClient graphQLClient = CreateGraphQLHttpClient("/getcourses");

      // const string qString = @"{courses{
      //       instructor,
      //       title,
      //       duration,
      //       ratings{
      //           studentName,
      //           starValue,
      //           review
      //       }
      //   }}";

      const string qString = @"{course(id:1) {
            instructor,
            title,
            duration,
            ratings{
                studentName,
                starValue,
                review
            }
        }}";

      var response = await graphQLClient.HttpClient.GetAsync(
          $"{UriString}?query={qString}");

      var result = response.Content.ReadAsStringAsync();
      Console.WriteLine(result.Result);
    }

    public static async Task GetCoursesViaHttpPost()
    {
      var graphQLClient = CreateGraphQLHttpClient();

      const string qString = @"{courses{
            instructor,
            title,
            duration,
            ratings{
                studentName,
                starValue,
                review
            }
        }}";

      var postRequest = new GraphQLRequest
      {
        Query = qString
      };

      var response = await graphQLClient.SendQueryAsync<dynamic>(postRequest);

      Console.WriteLine(response.Data["courses"]);
    }

    private static GraphQLHttpClient CreateGraphQLHttpClient(string path = "")
    {
      return new GraphQLHttpClient(
          new Uri($"{UriString}{path}"),
          new SystemTextJsonSerializer());
    }
  }
}