namespace HMS.Models
{
    public class Inventory
    {
        public int Id { get; set; } 
        public string ItemName { get; set; }
        public string Description { get; set; } 
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
    }
 
}