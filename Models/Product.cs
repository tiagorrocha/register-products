using System.ComponentModel.DataAnnotations;
namespace RegisterProducts.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public Product(string description)
        {
            this.Description = description;
        }
    }
}