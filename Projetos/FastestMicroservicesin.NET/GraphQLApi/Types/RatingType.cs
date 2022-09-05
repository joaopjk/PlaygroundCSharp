using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLApi.Data.Entities;

namespace GraphQLApi.Types
{
  public class RatingType : ObjectGraphType<Rating>
  {
    public RatingType()
    {
      Name = "Raging";
      Field(_ => _.Id, type: typeof(IdGraphType)).Description("Rating ID");
      Field(_ => _.CourseId);
      Field(_ => _.StudentName);
      Field(_ => _.Review);
      Field(_ => _.StarValue);
    }
  }
}