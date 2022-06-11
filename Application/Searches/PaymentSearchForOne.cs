using Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class PaymentSearchForOne : PaginationSearch
    {
        public int IdAccount { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public int CurrencyId { get; set; }
        public int PaymentCategoryId { get; set; }
        public IEnumerable<int> PaymentTypesIds { get; set; }
    }
}
