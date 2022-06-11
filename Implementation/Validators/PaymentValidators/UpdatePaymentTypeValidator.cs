using Application.Dto.Payments;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.PaymentValidators
{
    public class UpdatePaymentTypeValidator : AbstractValidator<UpdatePaymentTypeDto>
    {
        private readonly Context context;
        public UpdatePaymentTypeValidator(Context context)
        {
            this.context = context;
            RuleFor(x => x.IdPaymentType).NotEmpty().WithMessage("Payment type id is mandatory").Must(x => context.PaymentTypes.Any(y => y.Id == x)).WithMessage("Payment id not found");
        }

        public bool CheckCategoryID(int categoryId)
        {
            return context.PaymentCategories.Any(x => x.Id == categoryId);
        }
        public bool CheckNewName(string newName)
        {
            return !context.PaymentTypes.Any(x => x.Name == newName);
        }
    }
}
