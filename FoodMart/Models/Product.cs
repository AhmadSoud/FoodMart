using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMart.Models
{
    public class Product
    {
        [Key] // praimary key
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[MaxLength(50)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public float? Price { get; set; }

        public DateTime CreatedDate { get; set; }
        [ForeignKey("category")]
        public int Fk_CategoryId { get; set; }
        public Category category { get; set; }

        [EmailAddress]
        public string? Email {  get; set; }
        List<Cart>? Carts { get; set; }


        [NotMapped] // data anotation
        public string TempDate { get; set; }



    }
}
