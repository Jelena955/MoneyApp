using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccountDto
{
    public class AddMoneyDto : DtoBase
    {
        public int IdAccount { get; set; }
        public bool AddingMoney { get; set; } = true;
        public decimal HowMuchMoney { get; set; }
        public int IdCurrency { get; set; }
    }
}
