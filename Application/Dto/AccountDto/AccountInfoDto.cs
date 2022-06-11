using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccountDto
{
    public class AccountInfoDto :DtoBase
    {
        public int IdAccount { get; set; }
        public string FirstName_LastName { get; set; }
        public string BaseCurrencyName { get; set; }
        public string EmailAdress { get; set; }
        public int DayOfSalary { get; set; }
        public decimal AmountOfSalary { get; set; }
        public decimal AmountOfMoney { get; set; }

    }
}
