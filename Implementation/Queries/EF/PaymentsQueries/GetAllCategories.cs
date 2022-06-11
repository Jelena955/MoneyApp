using Application.Dto.Payments;
using Application.Queries.PaymentCategory;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.PaymentsQueries
{
    public class GetAllCategories : IGetAllCategories
    {
        private readonly Context context;

        public GetAllCategories(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 7;

        public string Name_UseCase => "Get all the Payment categories";

        public IEnumerable<GetPaymentCategoriesDto> Query(int search)
        {
            return this.context.PaymentCategories.Select(x => new GetPaymentCategoriesDto()
            {
                IdCategory = x.Id,
                Name = x.Name
            });
        }
    }
}
