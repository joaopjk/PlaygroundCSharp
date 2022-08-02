using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryPut
    { 
        public static string Template => "/categories/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;

        public static async Task<IResult> Action([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = await context.Categories.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Results.NotFound();

            category.Name = categoryRequest.Name;
            category.Active = categoryRequest.Active;
            await context.SaveChangesAsync();
            return Results.Ok(category);
        }
    }
}
