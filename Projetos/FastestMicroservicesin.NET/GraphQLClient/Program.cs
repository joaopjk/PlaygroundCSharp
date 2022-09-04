using System;

namespace GraphQLClient
{
  static class Program
  {
    static void Main(string[] _)
    {
      GraphQLApiClient.GetCoursesViaHttpGet().Wait();
    }
  }
}
