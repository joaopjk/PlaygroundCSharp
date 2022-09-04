using System;

namespace Api.Domain.Models.User
{
  public class UserModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    private DateTime _creatAt;
    public DateTime CreateAt
    {
      get { return _creatAt; }
      set { _creatAt = value == default ? DateTime.UtcNow : value; }
    }
    public DateTime UpdateAt { get; set; }
  }
}
