using FoodMart.Models;
using FoodMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController (ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Create(Category category, IFormFile ImageFile) 
        {
            _categoryService.AddCategory(category, ImageFile);
            return RedirectToAction("Index");
        
        }

        public IActionResult GetCategories()
        {
           var categories= _categoryService.GetCategories();
            return View("GetCategories", categories);

        }
        [HttpPost]
        public IActionResult Edit(Category category, IFormFile ImageFile) 
        {
            _categoryService.UpdateCategory(category, ImageFile);
            return RedirectToAction("GetCategories");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
          var category = _categoryService.GetCategoryById(id);
            if (category == null) 
                return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("GetCategories");
        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id); // أو من DbContext مباشرة
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    }
}
