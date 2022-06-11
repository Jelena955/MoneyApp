using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class PreveiwMoneySearch : BaseSearch
    {
        public int IdAccount { get; set; }
        public int IdCurrency { get; set; }
        public decimal MinimumMoney { get; set; }
        public decimal MaximumMoney { get; set; }

    }
}
