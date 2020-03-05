using System.ComponentModel.DataAnnotations;

namespace RegisterProducts.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Description{ get; set; }
        public int ProductId { get; set; }

        public Item (string description, int productId)
        {
            this.Description = description;
            this.ProductId = productId;
        }

    }
}