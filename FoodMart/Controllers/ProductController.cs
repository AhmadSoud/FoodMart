using FoodMart.Models;
using FoodMart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodMart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Product product, IFormFile ImageFile) 
        {
            _productService.AddProduct(product, ImageFile);
            return RedirectToAction("IndexVM");



        }
        //public IActionResult GetProducts() 
        //{
        //   var products= _productService.GetProducts();
        //    return View(products);
  
        
        //}


        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            var productViewModels = products.Select(p => new ProductViewModel
            {
                product = p,
                categories = null
            }).ToList();

            return View(productViewModels);
        }


        //------------------GetProductsByCategory----------------

        public IActionResult GetProductsByCategory(string categoryName)
        {
            var products = _productService.GetProducts()
                .Where(p => p.category != null && p.category.Name == categoryName)
                .ToList();

            var productViewModels = products.Select(p => new ProductViewModel
            {
                product = p,
                categories = null
            }).ToList();

            return View("GetProducts", productViewModels); 
        }




        public IActionResult IndexVM()
        {
            var categories = _categoryService.GetCategories()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                })
                .ToList();

            var viewModel = new ProductViewModel
            {
                product = new Product(),
                categories = categories
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(Product product, IFormFile ImageFile)
        {
            _productService.UpdateProduct(product, ImageFile);
            return RedirectToAction("GetProducts"); 
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            var categories = _categoryService.GetCategories()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                })
                .ToList();

            var viewModel = new ProductViewModel
            {
                product = product,
                categories = categories
            };

            return View(viewModel);
        }




        [HttpPost]

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("GetProducts");
        }


        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id); 
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



    }
}
