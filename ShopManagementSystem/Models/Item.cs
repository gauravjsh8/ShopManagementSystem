namespace ShopManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  decimal Price { get; set; }
        public  int Discount { get; set; }
        public  int Stock { get; set; }
    }
}
