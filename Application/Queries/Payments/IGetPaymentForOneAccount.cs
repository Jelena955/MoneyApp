using Application.Core;
using Application.Dto.Pagination;
using Application.Dto.Payments;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Payments
{
    public interface IGetPaymentForOneAccount : IQuery<PaymentSearchForOne,PaginationReturn<PaymentForOneUserDto>>
    {
    }
}
