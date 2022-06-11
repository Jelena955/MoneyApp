using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto.Pagination;
using Application.Dto.Payments;
using Application.Searches;

namespace Application.Queries.Payments
{
    public interface IGetPaymentForUser : IQuery<PaymentSearch,PaginationReturn<GetPayments>>
    {
    }
}
