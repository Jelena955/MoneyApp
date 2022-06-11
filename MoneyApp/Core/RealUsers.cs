using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Core
{
    public class AnonymusUser : IAppActor
    {
        public int Id => -1;

        public string Identity => "Anonymus user";

        public IEnumerable<int> AllowedActions => new List<int> { 2,3};
    }

    public class JwtUser : IAppActor
    {
        public string Identity { get; set; }

        public int Id { get; set; }
        public IEnumerable<int> AllowedActions { get; set; } = new List<int>();

    }
}
