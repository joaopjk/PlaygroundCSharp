using GraphQL.Types;
using GraphQLApi.Data;

namespace GraphQLApi.Types
{
    public class PaymentTypeEnum : EnumerationGraphType<PaymentType> { }
    //public class PaymentTypeEnum : EnumerationGraphType
    //{
    //    public PaymentTypeEnum()
    //    {
    //        Name = "PaymentType";
    //        Description = "Payment Type for the Courses";
    //        Add("FREE", "Free Course");
    //        Add("PAID", "Paid Course");
    //    }
    //}
}
