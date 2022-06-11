using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.PaymentValidators
{
    public class RemovePaymentValidator : AbstractValidator<int>
    {
        public RemovePaymentValidator(Context context)
        {
            RuleFor(x => x).NotEmpty().WithMessage("Id of payment to delete is manditory").Must(x => context.Payments.Any(y => y.Id == x)).WithMessage("Payment not found").OverridePropertyName("Payment id");
        }
    }
}
