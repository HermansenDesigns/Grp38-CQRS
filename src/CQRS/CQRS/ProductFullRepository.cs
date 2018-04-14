using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class ProductFullRepository : Repository<ProductFull>
    {
        private CQRSContext _context;
        public ProductFullRepository(CQRSContext context) : base(context)
        {
            _context = context; 
        }

        public override void Save(ProductFull product, int expected)
        {
            if (product.Version == expected)
            {
                base.Save(product, expected);
            }
            else
            {
                throw new InvalidEnumArgumentException("Version Error");
            }
        }

        public ProductFull GetById(Guid id)
        {
            return _context.Products.First(x => x.Id == id); 
        }
    }
}
