using Delivery.Application.Response.CardItemResponse;
using Delivery.Domain.Model;

public class PaggedListCardItemtResponse : CardItemRequest
{
        public ulong CardId { get; set; }
        public virtual Card Card { get; set; }
        public ulong ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
}