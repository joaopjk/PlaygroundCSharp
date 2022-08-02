using IWantApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryGetAll
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;
        public static async Task<IResult> Action(ApplicationDbContext context)
        {
            return Results.Ok(await context.Categories.ToListAsync());
        }
    }
}
