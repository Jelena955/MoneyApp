using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class NewPaymentDto : DtoBase
    {
        public int AccountId { get; set; }
        public int CurrencyId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal AmountPaid{ get; set; }
    }
}
