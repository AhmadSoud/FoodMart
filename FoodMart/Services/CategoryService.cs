using FoodMart.Data;
using FoodMart.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMart.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly FoodMartContext _Context;
        public CategoryService(FoodMartContext Context)
        {
            _Context = Context;
        }

        public void AddCategory(Category category, IFormFile ImageFile)
        {
            var uploadsFolder= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" , "images");

            if (ImageFile != null && ImageFile.Length > 0)
            {
                Directory.CreateDirectory(uploadsFolder);
                var uniqeFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;

                var filePath = Path.Combine(uploadsFolder, uniqeFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                category.ImagePath = " /images/" + uniqeFileName;
            }
            else 
            {
                category.ImagePath = null;
            }
            category.CreatedDate = DateTime.Now;

            _Context.Categories.Add(category);
            _Context.SaveChanges();
        }

        public List<Category> GetCategories() 
        {
            return _Context.Categories.ToList();
        
        }


        public void UpdateCategory(Category category, IFormFile ImageFile)
        {
            var existCategory= _Context.Categories.Find(category.Id);

            if (existCategory != null) 
            {
                existCategory.Name= category.Name;
                existCategory.Description= category.Description;


                //

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    Directory.CreateDirectory(uploadsFolder);
                    var uniqeFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;

                    var filePath = Path.Combine(uploadsFolder, uniqeFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    category.ImagePath = " /images/" + uniqeFileName;
                }
                else
                {
                    category.ImagePath = null;
                }

                category.CreatedDate = DateTime.Now;
                //_Context.Categories.Add(category);
                _Context.SaveChanges();

            }


        }

        public Category GetCategoryById(int id) 
        {
            return _Context.Categories.FirstOrDefault(c=>c.Id==id);
        
        }

        public void DeleteCategory(int id)
        {
            var existCategory = _Context.Categories.Find(id);
            _Context.Categories.Remove(existCategory);
            _Context.SaveChanges();

        }





    }
}
