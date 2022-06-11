using Application.Core;
using Application.Dto.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Currency
{
    public interface IAddNewCurrency : ICommand<NewCurrencyDto>
    {
    }
}
