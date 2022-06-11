using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payments : EntityBase
    {
        public int AccountId { get; set; }
        public int CurrencyID { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Amount { get; set; }

        public Accounts Account { get; set; }
        public Currencys Currency { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}
