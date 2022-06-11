using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Currency
{
    public class UpdateCurrencyDto : DtoBase
    {
        public string NewName { get; set; }
        public int CurrencyId { get; set; }
    }
}
