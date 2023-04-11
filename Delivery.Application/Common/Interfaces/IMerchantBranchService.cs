using Delivery.Application.Requests.MerchantBranch;
using Delivery.Application.Response.MerchantBranchResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface IMerchantBranchService : IBaseService<MerchantBranch, MerchantBranchResponse, MerchantBranchRequest>
    {
    }
}
