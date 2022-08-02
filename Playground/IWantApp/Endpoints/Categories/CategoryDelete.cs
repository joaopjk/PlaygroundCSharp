using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryDelete
    {
        public static string Template => "/categories/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handler => Action;

        public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var category = await context.Categories.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Results.NotFound();

            context.Remove(category);
            await context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
