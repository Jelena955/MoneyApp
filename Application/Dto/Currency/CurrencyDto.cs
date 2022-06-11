using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Currency
{
    public class CurrencyDto : DtoBase
    {
        public int IdCurrency { get; set; }
        public string Name { get; set; }
    }
}
