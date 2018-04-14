using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    class Handlers
    {
        public class RenameProductCommandHandler : ICommandHandler<RenameProductCommand>
        {
            private Repository<ProductFull> _repository;

            public RenameProductCommandHandler(Repository<ProductFull> repository)
            {
                _repository = repository;
            }

            public void Execute(RenameProductCommand command)
            {
                if (command == null || _repository==null)
                {
                    throw new ArgumentException("command or repository null");
                }

                var item = _repository.Get(command.Id);
                item.ProductName = command.ProductName;
                item.Version++; 
                _repository.save(item,item.Version); 
            }
        }
    }
}
