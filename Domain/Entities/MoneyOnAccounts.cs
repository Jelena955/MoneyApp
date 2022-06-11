using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MoneyOnAccounts : EntityBase
    {
        public int AccountId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }

        public Accounts Account { get; set; }
        public Currencys Currency { get; set; }

    }
}
