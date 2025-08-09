using FoodMart.Models;
namespace FoodMart.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category, IFormFile ImageFile);
        List<Category> GetCategories();
        void UpdateCategory(Category category, IFormFile ImageFile);
        Category GetCategoryById(int id);
        void DeleteCategory(int id);

    }
}
