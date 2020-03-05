using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegisterProducts.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(1024, ErrorMessage = "This field must contain a maximum of 1024 characters")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public List<ItemDto> Items { get; set; }

        public ProductDto(){}
        public ProductDto(int id, string description, List<ItemDto> items)
        {
            this.Id = id;
            this.Description = description;
            this.Items = items;
        }
    }
}