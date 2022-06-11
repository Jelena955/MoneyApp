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
    public class NewPaymentCategoryValidator : AbstractValidator<NewPaymentCategoryDto>
    {
        public NewPaymentCategoryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory").MaximumLength(30).WithMessage("Maximum is 30 characters").Must(x => !context.PaymentCategories.Any(y => y.Name == x)).WithMessage("That name already exists").Matches(@"^[A-Z][a-z\s]{1,29}$").WithMessage("Only letters are allowed, capital letter must be Upper case");

        }
    }
}
