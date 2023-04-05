using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.MerchantResponse
{
    public class GetMerchantResponse : MerchantResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ShortDiscreption { get; set; }
        public string IsActive { get; set; }
        public ulong MerchantCategoryId { get; set; }
    }
}

