using FoodMart.Models;

namespace FoodMart.Services
{
    public interface IProductService
    {
        void AddProduct(Product product , IFormFile ImageFile);



        List<Product> GetProducts();

        void UpdateProduct(Product product, IFormFile ImageFile);

        Product GetProductById(int id);

        void DeleteProduct(int id);


    }
}
