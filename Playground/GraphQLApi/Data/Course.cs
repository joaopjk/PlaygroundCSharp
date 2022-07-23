using System;
using System.Collections.Generic;

namespace GraphQLApi.Data
{
    public class Course
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Level { get; set; }
        public String Instructor { get; set; }
        public PaymentType PaymentType { get; set; }
        public int Duration { get; set; }
        //public List<Section> Sections { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
