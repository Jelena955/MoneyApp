using Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class PaymentSearch : PaginationSearch
    {
        public int PaymentTypeId { get; set; }
        public int PaymentCategoryId { get; set; }
        public int CurrencyId { get; set; }
        public int AccountId { get; set; }
    }
}
