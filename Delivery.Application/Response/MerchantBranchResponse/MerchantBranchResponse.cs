using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.MerchantBranchResponse
{
    public class MerchantBranchResponse : BaseResponse
    {
        public ulong MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public string Location { get; set; }
        public string MerchantCoverage { get; set; }
    }
}
