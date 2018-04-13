using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class Event : IMessage
    {
        public int Version;
    }
}
