using System;

namespace GraphQLApi.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public String StudentName { get; set; }
        public String Review { get; set; }
        public int StarValue { get; set; }
    }
}
