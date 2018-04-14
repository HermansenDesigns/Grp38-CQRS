using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Events
{
    public class ProductRenameEventHandler : IHandle<ProductRenameEvent>
    {
        private ProductFullRepository _repository;
        private ReadContext _context;

        public ProductRenameEventHandler(ProductFullRepository repository, ReadContext context)
        {
            _repository = repository;
            _context = context; 
        }

        public void Handle(ProductRenameEvent @event)
        {
            var product = _repository.GetById(@event.Id);
            product.ProductName = @event.ProductName;
            _context.SaveChanges(); 
        }
    }
}
