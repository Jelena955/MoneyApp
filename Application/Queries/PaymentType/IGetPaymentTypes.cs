using Application.Core;
using Application.Dto.Payments;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.PaymentType
{
    public interface IGetPaymentTypes : IQuery<PaymentTypeSearch,IEnumerable<GetPaymentTypeDto>>
    {
    }
}
