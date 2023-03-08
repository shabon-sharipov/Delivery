namespace Delivery.Domain.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }
}