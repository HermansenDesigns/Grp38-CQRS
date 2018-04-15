using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public interface ICommandHandler<TEntity> where TEntity : Command
    {
        void Handle(TEntity command);
        
    }
}
