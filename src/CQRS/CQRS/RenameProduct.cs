using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    class RenameProduct
    {
        public readonly string ProductName;
        public readonly Guid Id;

        public RenameProduct(string productName, Guid id)
        {
            ProductName = productName;
            Id = id;
        }
    }
}
