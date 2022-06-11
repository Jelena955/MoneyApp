using Application.Dto.Currency;
using Application.Queries.Currency;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.CurrencyQueries
{
    public class GetCurrency : IGetCurrency
    {
        private readonly Context context;

        public GetCurrency(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 11;

        public string Name_UseCase => "Get all currency's with search";

        public IEnumerable<CurrencyDto> Query(CurrencySearch search)
        {
            var query = this.context.Currencys.AsQueryable();

            if (search.CurrencyId != 0)
            {
                query = query.Where(x => x.Id == search.CurrencyId);
            }
            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            return query.Select(x => new CurrencyDto()
            {
                IdCurrency = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
