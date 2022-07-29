using GraphQL;
using GraphQLApi.Data;

namespace GraphQLApi.Queries
{
    public class Query
    {
        [GraphQLMetadata("courses")]
        public List<Course> GetCourses()
        {
            return CouseData();
        }

        private List<Course> CouseData()
        {
            return new List<Course>()
            {
                new Course{
                    Id = 1,
                    Title = "Fastest Microservices",
                    Duration = 540,
                    Level = "All",
                    Instructor = "João Cícero",
                    PaymentType = PaymentType.PAID,
                    Ratings = GetRating(1)
                },
                 new Course{
                    Id = 2,
                    Title = "Software Devlopment Full Stack",
                    Duration = 320,
                    Level = "Expert",
                    Instructor = "João Cícero",
                    PaymentType = PaymentType.PAID,
                    Ratings = GetRating(2)
                }
            };
        }

        [GraphQLMetadata("course")]
        public Course GetCourse(int id)
        {
            return CouseData().ToList().FirstOrDefault(c => c.Id == id) ?? new Course();
        }

        public List<Rating> GetRating(int courseId)
        {
            var ratings = new List<Rating>
            {
                new Rating { StudentName = "Shree", StarValue = 5, Review = "Very Useful" , CourseId=1 },
                new Rating { StudentName = "Mark", StarValue = 5, Review = "Very Useful", CourseId=1 },
                new Rating { StudentName = "David", StarValue = 5, Review = "Very Useful" , CourseId=1},
                new Rating { StudentName = "Mark", StarValue = 5, Review = "Very Useful" , CourseId=2 },
                new Rating { StudentName = "Mark", StarValue = 5, Review = "Very Useful", CourseId=3 },
                new Rating { StudentName = "David", StarValue = 5, Review = "Very Useful" , CourseId=3}
            };
            return ratings.Where(r => r.CourseId == courseId).ToList();
        }
    }
}

