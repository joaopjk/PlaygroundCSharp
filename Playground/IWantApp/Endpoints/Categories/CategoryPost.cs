using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;

        public static async Task<IResult> Action(CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            return Results.Ok();
        }
    }
}
