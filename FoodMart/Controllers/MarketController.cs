using FoodMart.Models;
using FoodMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMart.Controllers
{
    public class MarketController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public MarketController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            var categories = _categoryService.GetCategories();

            var vm = new indexVM
            {
                products = products,
                categories = categories
            };

            var viewModelList = new List<indexVM> { vm };

            return View(viewModelList); 
        }



    }
}
