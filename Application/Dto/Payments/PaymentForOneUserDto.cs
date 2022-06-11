using Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class PaymentForOneUserDto : DtoBase
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int PaymentCategoryId { get; set; }
        public string PaymentCategoryName { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
