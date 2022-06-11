using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.PaymentValidators
{
    public class PaymentCategoryDeleteValidation : AbstractValidator<int>
    {
        public PaymentCategoryDeleteValidation(Context context)
        {
            RuleFor(x => x).NotEmpty().WithMessage("Id category must be supplied").Must(x => context.PaymentCategories.Any(y => y.Id == x)).WithMessage("Supplied id does not exist");
        }
    }
}
