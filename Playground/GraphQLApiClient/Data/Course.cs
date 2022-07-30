using System.Collections.Generic;

namespace GraphQLApiClient.Data
{
    public class Course
    {
        public string Title { get; set; }
        public string Level { get; set; }
        public string Instructor { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
