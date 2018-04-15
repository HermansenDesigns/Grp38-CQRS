using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace CQRS.Query
{
    public interface ICommandAppliable<TEntity> where TEntity : Command.Command
    {
        void Apply(TEntity entity);
    }
}
