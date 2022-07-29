namespace GraphQLApi.Data
{
    public class Section
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SeqNo { get; set; }
        public string Title { get; set; }
        public List<Lecture> MyProperty { get; set; }
    }
}
