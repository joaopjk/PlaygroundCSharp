using System.ComponentModel;

namespace GraphQLApi.Data.Entities
{
  public enum PaymentType
  {
    [Description("Free Course")]
    FREE = 0,
    [Description("Paid Course")]
    PAID = 1
  }
}