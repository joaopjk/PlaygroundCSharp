namespace GraphQLApi.Data.Entities
{
  public class Assignment : Lecture
  {
    public string Instructions { get; set; }
    public string Questions { get; set; }
  }
}