using System.Collections.Generic;

namespace GraphQLApiClient.Data
{
    public class Course
    {
        public string title { get; set; }
        public string level { get; set; }
        public string instructor { get; set; }
        public List<Rating> ratings { get; set; }
    }
}
