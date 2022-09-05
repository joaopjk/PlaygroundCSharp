using GraphQL.Types;

namespace GraphQLApi.Types
{
  //   public class PaymentTypeEnum : EnumerationGraphType<PaymentType>
  //   {

  //   }
  public class PaymentTypeEnum : EnumerationGraphType
  {
    public PaymentTypeEnum()
    {
      Name = "PaymentType";
      Description = "Payment type for the Course.";
      AddValue("FREE", "Free Course", 0);
      AddValue("PAID", "Paid Course", 1);
    }
  }
}