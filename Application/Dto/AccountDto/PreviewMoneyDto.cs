using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccountDto
{
    public class PreviewMoneyDto : DtoBase
    {
        public string CurrencyName { get; set; }
        public decimal AmountOfMoney { get; set; }
    }
}
