using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Payments
{
    public interface IRemovePayment : ICommand<int>
    {
    }
}
