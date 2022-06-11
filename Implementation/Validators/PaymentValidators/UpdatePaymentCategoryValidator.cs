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
    public class UpdatePaymentCategoryValidator : AbstractValidator<UpdatePaymentCategoryDto>
    {
        public UpdatePaymentCategoryValidator(Context context)
        {

            RuleFor(x => x.IdPaymentCategory).NotEmpty().WithMessage("Id payment category is manditory").Must(x => context.PaymentCategories.Any(y => y.Id == x)).WithMessage("Given id does not exist in DB");
            RuleFor(x => x.NewNameCategory).NotEmpty().WithMessage("You need to specifie new name").Must(x => !context.PaymentCategories.Any(y => y.Name == x)).WithMessage("That name is taken").Matches(@"^[A-Z][a-z\s]{1,29}$").WithMessage("Only letters are allowed, capital letter must be Upper case");

        }
    }
}
