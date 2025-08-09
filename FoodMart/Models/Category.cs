namespace FoodMart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; }                   

        public List<Product> products { get; set; }
    }
}
