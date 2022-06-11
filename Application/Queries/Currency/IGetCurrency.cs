using Application.Core;
using Application.Dto.Currency;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Currency
{
    public interface IGetCurrency : IQuery<CurrencySearch,IEnumerable<CurrencyDto>>
    {
    }
}
