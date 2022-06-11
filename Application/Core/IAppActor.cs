using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IAppActor
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> AllowedActions { get; }
    }
}
