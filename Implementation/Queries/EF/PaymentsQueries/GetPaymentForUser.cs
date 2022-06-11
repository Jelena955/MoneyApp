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
    public class GetPaymentForUser : IGetPaymentForUser
    {
        private readonly Context context;

        public GetPaymentForUser(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 19;

        public string Name_UseCase => "Get's the payments";

        public PaginationReturn<GetPayments> Query(PaymentSearch search)
        {
            var query = this.context.Accounts.AsQueryable();

            if(search.AccountId != 0)
            {
                query = query.Where(x => x.Id == search.AccountId);
            }
            if(search.CurrencyId != 0)
            {
                query = query.Where(x => x.Payments.Any(y=> y.CurrencyID == search.CurrencyId));
            }
            if(search.PaymentTypeId != 0)
            {
                query = query.Where(x => x.Payments.Any(y => y.PaymentTypeId == search.PaymentTypeId));
            }
            if(search.PaymentCategoryId != 0)
            {
                query = query.Where(x => x.Payments.Any(y => y.PaymentType.PaymentCategoryId == search.PaymentCategoryId));
            }


            return  new PaginationReturn<GetPayments>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new GetPayments()
                {
                    IdAccount = x.Id,
                    Name_LastName = x.User.Name + " " + x.User.LastName,
                    Payments = x.Payments.Select(y => new _innerPayments()
                    {
                        IdCurrency = y.CurrencyID,
                        IdPayment = y.Id,
                        NameCurrency = y.Currency.Name,
                        AmountPaid = y.Amount,
                        PaymentType = new _innerPaymentType()
                        {
                            Name = y.PaymentType.Name,
                            IdPaymentType = y.PaymentType.Id,
                            PaymentCategory = new _innerPaymentCategory()
                            {
                                Name = y.PaymentType.PaymentCategory.Name,
                                IdPaymentCategory = y.PaymentType.PaymentCategory.Id
                            }
                        }
                    }).ToList()
                }).ToList()
            };
        }
    }
}
