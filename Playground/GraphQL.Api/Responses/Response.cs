using GraphQL.Api.Data;
using System.Collections.Generic;

namespace GraphQL.Api.Responses
{
    public class Response
    {
        public List<SubField> subFields { get; set; }
    }
    public class SubField
    {
        public List<Course> result { get; set; }
    }
}
