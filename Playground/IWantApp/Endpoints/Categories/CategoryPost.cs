using IWantApp.Domain.Products;
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
            var category = new Category(categoryRequest.Name, "Test", "Test");

            if (!category.IsValid)
            {
                var errors = category.Notifications
                    .GroupBy(_ => _.Key)
                    .ToDictionary(_ => _.Key, _ =>
                        _.Select(_ => _.Message).ToArray());
                return Results.ValidationProblem(errors);
            }

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}
