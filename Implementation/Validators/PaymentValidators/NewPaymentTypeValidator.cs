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
    public class NewPaymentTypeValidator : AbstractValidator<NewPaymentTypeDto>
    {
        public NewPaymentTypeValidator(Context context)
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Payment category is required").Must(x => context.PaymentCategories.Any(y => y.Id == x)).WithMessage("Payment category not found");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Must(x => !context.PaymentTypes.Any(y => y.Name == x)).WithMessage("That name is taken");
        }
    }
}
