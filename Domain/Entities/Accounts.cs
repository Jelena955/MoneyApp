using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class Accounts : EntityBase
    {
        public int Id_User { get; set; }
        public int CurrencyId { get; set; }
        public int RegularTimeOFSalary { get; set; }
        public decimal Salary { get; set; }
        public DateTime LastTimeHere { get; set; }

        public User User { get; set; }
        public Currencys Currency { get; set; }
        public List<MoneyOnAccounts> Money { get; set; }
        public List<Payments> Payments { get; set; }

    }
}
