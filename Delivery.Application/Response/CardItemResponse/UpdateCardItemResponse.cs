using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.CardItemResponse
{
    public class UpdateCardItemRequest : CardItemRequest
    {
        public ulong CardId { get; set; }
        public virtual Card Card { get; set; }
        public ulong ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
