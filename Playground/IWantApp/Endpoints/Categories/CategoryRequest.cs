using System.ComponentModel.DataAnnotations;

namespace IWantApp.Endpoints.Categories
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get;  set; }
    }
}
