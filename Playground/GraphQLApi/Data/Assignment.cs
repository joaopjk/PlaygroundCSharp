using System;

namespace GraphQLApi.Data
{
    public class Assignment : Lecture
    {
        public String Instructions { get; set; }
        public String Questions { get; set; }
    }
}
