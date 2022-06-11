using Application.Dto.Payments;
using Application.Queries.PaymentType;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.PaymentsQueries
{
    public class GetPaymentTypes : IGetPaymentTypes
    {
        private readonly Context context;

        public GetPaymentTypes(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 16;

        public string Name_UseCase => "Gets the paymentTypes with search";

        public IEnumerable<GetPaymentTypeDto> Query(PaymentTypeSearch search)
        {
            var query = this.context.PaymentTypes.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            if(search.IdCategory != 0)
            {
                query = query.Where(x => x.PaymentCategory.Id == search.IdCategory);
            }
            if(search.idType != 0)
            {
                query = query.Where(x => x.Id == search.idType);
            }

            return query.Select(x => new GetPaymentTypeDto()
            {
                CategoryName = x.PaymentCategory.Name,
                CategoryId = x.PaymentCategory.Id,
                TypeId = x.Id,
                TypeName = x.Name
            });

        }
    }
}
