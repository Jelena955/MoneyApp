using Application.Dto.AccountDto;
using Application.Queries.Account;
using Application.Searches;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.AccountQueries
{
    public class PreviewMoneyOnAccount : IPreviewMoneyOnAccount
    {
        private readonly Context context;

        public PreviewMoneyOnAccount(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 5;

        public string Name_UseCase => "Previewing money on account";

        public IEnumerable<PreviewMoneyDto> Query(PreveiwMoneySearch search)
        {
                var query = this.context.MoneyOnAccounts.AsQueryable();

                if (search.IdAccount != 0) 
                {
                    query = query.Where(x => x.AccountId == search.IdAccount);
                }
                if (search.IdCurrency != 0)
                {
                    query = query.Where(x => x.CurrencyId == search.IdCurrency);
                }

                var helpingMarker = false;

                if (search.MaximumMoney != 0 && search.MinimumMoney != 0)
                {
                    query = query.Where(x => x.Amount <= search.MaximumMoney && x.Amount >= search.MinimumMoney);
                    helpingMarker = true;
                }
                if (!helpingMarker)
                {
                    if (search.MaximumMoney != 0)
                    {
                        query = query.Where(x => x.Amount <= search.MaximumMoney);
                    }
                    if (search.MinimumMoney != 0)
                    {
                        query = query.Where(x => x.Amount >= search.MinimumMoney);
                    }
                }
            return query.Where(x => x.Amount != 0).Select(x => new PreviewMoneyDto()
            {
                AmountOfMoney = x.Amount,
                CurrencyName = x.Currency.Name
            });
        }
    }
}
