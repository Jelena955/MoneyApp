using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Currencys : EntityBase
    {
        public string Name { get; set; }

        public List<Accounts> Accounts { get; set; }
        public List<MoneyOnAccounts> Money { get; set; }
        public List<Payments> Payment { get; set; }

    }
}
