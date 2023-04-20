using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.MerchantBranch
{
    public abstract class MerchantBranchRequest : BaseRequest
    {
        public ulong MerchantId { get; set; }
        public string Location { get; set; }
        public string MerchantCoverage { get; set; }
        public double PointLat { get; set; }
        public double PointLng { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
        public MerchantStatus MerchantStatus { get; set; }
    }
}
