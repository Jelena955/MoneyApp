using Application.Dto.Pagination;
using Application.Dto.Payments;
using Application.Queries.Payments;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.PaymentsQueries
{
    public class GetPaymentForOneAccount : IGetPaymentForOneAccount
    {
        private readonly Context context;

        public GetPaymentForOneAccount(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 20;

        public string Name_UseCase => "Getting all payments for one user";

        public PaginationReturn<PaymentForOneUserDto> Query(PaymentSearchForOne search)
        {

            var query = this.context.Payments.AsQueryable();

            var helpingMarker = false;

            if (search.MaximumAmount != 0 && search.MinimumAmount != 0)
            {
                query = query.Where(x => x.Amount <= search.MaximumAmount && x.Amount >= search.MinimumAmount);
                helpingMarker = true;
            }
            if (!helpingMarker)
            {
                if (search.MaximumAmount != 0)
                {
                    query = query.Where(x => x.Amount <= search.MaximumAmount);
                }
                if (search.MinimumAmount != 0)
                {
                    query = query.Where(x => x.Amount >= search.MinimumAmount);
                }
            }
            if (search.CurrencyId != 0) 
            {
                query = query.Where(x => x.CurrencyID == search.CurrencyId);
            }

            if (search.PaymentCategoryId !=0)
            {
                query = query.Where(x => x.PaymentType.PaymentCategoryId == search.PaymentCategoryId);
            }

            if (search.PaymentTypesIds != null) 
            {
                if (search.PaymentTypesIds.Count() > 0)
                {
                    query = query.Where(x => search.PaymentTypesIds.Contains(x.PaymentTypeId));
                }
            }

            return new PaginationReturn<PaymentForOneUserDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Where(x => x.AccountId == search.IdAccount).Select(x => new PaymentForOneUserDto()
                {
                    AmountPaid = x.Amount,
                    CurrencyId = x.CurrencyID,
                    CurrencyName = x.Currency.Name,
                    PaymentCategoryId = x.PaymentType.PaymentCategoryId,
                    PaymentCategoryName = x.PaymentType.PaymentCategory.Name,
                    PaymentTypeId = x.PaymentTypeId,
                    PaymentTypeName = x.PaymentType.Name
                }).ToList()
            };
        }
    }
}
