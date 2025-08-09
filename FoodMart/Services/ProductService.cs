using FoodMart.Data;
using FoodMart.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMart.Services
{
    public class ProductService: IProductService
    {

        private readonly FoodMartContext _context;
        public ProductService (FoodMartContext context) 
        {
            _context = context;
        }

        public void AddProduct(Product product, IFormFile ImageFile)
        {
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

                product.ImagePath = " /images/" + uniqeFileName;
            }
            else
            {
                product.ImagePath = null;
            }
            product.CreatedDate = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public List<Product> GetProducts()
        {
            return _context.Products
                .Include(p => p.category) 
                .ToList();
        }


        public void DeleteProduct(int id)
        {
            var existProduct = _context.Products.Find(id);

            if (existProduct != null)
            {
                _context.Products.Remove(existProduct);
                _context.SaveChanges();
            }
            else
            {
                
            }
        }
        public void UpdateProduct(Product product, IFormFile ImageFile)
        {
            var existproduct = _context.Products.Find(product.Id);

            if (existproduct != null)
            {
                existproduct.Name = product.Name;
                existproduct.Description = product.Description;
                existproduct.Price = product.Price;
                existproduct.Fk_CategoryId = product.Fk_CategoryId;

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

                    existproduct.ImagePath = "/images/" + uniqeFileName; // ✅ صحح هنا
                }

                existproduct.CreatedDate = DateTime.Now; // ✅ صحح هنا

                _context.SaveChanges();
            }
        }





        public Product GetProductById(int id)

        {
            return _context.Products.FirstOrDefault(c => c.Id == id);

        }
    }
}
