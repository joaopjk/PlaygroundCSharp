using GraphQL.Types;

namespace GraphQL.Api.Types
{
    public class PaymentTypeEnum : EnumerationGraphType
    {
        public PaymentTypeEnum()
        {
            Name = "PaymentType";
            Description = "Payment Type for the Course.";
            AddValue("FREE", "Free Course", 0);
            AddValue("PAID", "Paid Course", 1);
        }
    }
}
