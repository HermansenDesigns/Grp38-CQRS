using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class ProductFull
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Rating { get; set; }
        public int Stock { get; set; }
        public int Version { get; set; }
    }
}
