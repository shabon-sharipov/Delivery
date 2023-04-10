using Delivery.Domain.Abstract;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Merchant : EntityBase
    {
        public string Name { get; set; }
        public string ShortDiscreption { get; set; }
        public string IsActive { get; set; }

        public ulong MerchantCategoryId { get; set; }
        public virtual MerchantCategory MerchantCategory { get; set; }

        public virtual IEnumerable<MerchantBranch> MerchantBranchs { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
