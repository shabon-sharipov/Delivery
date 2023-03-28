using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Abstract
{
    public abstract class Category : EntityBase
    {
        public string Name { get; set; }
        public string ShortDescreption { get; set; }

    }
}
