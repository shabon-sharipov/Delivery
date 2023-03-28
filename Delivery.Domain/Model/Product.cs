using Delivery.Domain.Abstract;

namespace Delivery.Domain.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }

        public ulong CategoryId { get; set; }
        public virtual ProductCategory CategoryProduct { get; set; }

        public ulong MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }

        public bool IsActive { get; set; }
    }
}