namespace RegisterProducts.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ItemDto(){}
        public ItemDto (int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
    }
}