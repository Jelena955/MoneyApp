using Application.Core;
using Application.Dto.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Payments
{
    public interface INewPayment : ICommand<NewPaymentDto>
    {
    }
}
