namespace GraphQL.Api.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public string Review { get; set; }
        public int StarValue { get; set; }
    }
}
