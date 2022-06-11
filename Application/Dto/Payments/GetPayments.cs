using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class GetPayments : DtoBase
    {
        public int IdAccount { get; set; }
        public string Name_LastName { get; set; }
        public IEnumerable<_innerPayments> Payments { get; set; }


    }
    public class _innerPayments
    {
        public int IdPayment { get; set; }
        public int IdCurrency { get; set; }
        public string NameCurrency { get; set; }
        public decimal AmountPaid { get; set; }
        public _innerPaymentType PaymentType { get; set; }

    }
    public class _innerPaymentType
    {
        public int IdPaymentType { get; set; }
        public string Name { get; set; }
        public _innerPaymentCategory PaymentCategory { get; set; }
    }
    public class _innerPaymentCategory 
    {
        public int IdPaymentCategory { get; set; }
        public string Name { get; set; }
    }

}
