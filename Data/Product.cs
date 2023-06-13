using System.ComponentModel.DataAnnotations.Schema;

namespace FECoffeeShop.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        public short Stock { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        //[ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        //public virtual Category Category { get; set; } = null!; 
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
