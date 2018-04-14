using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    
        public class RenameProductCommandHandler : ICommandHandler<RenameProductCommand>
        {
            private ProductFullRepository _repository;

        public RenameProductCommandHandler(ProductFullRepository repository)
        {
            _repository = repository;
        }

        public void Execute(RenameProductCommand command)
            {
                if (command == null || _repository==null)
                {
                    throw new ArgumentException("command or repository null");
                }

                var item = _repository.GetById(command.Id);
                item.ProductName = command.ProductName;
                item.Version++; 
                _repository.Save(item,item.Version); 
            }
        }
    
}
