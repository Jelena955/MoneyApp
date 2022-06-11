using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class PaymentTypeSearch : BaseSearch
    {
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public int idType { get; set; }
    }
}
