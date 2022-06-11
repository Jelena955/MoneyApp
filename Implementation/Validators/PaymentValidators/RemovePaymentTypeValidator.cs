using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.PaymentValidators
{
    public class RemovePaymentTypeValidator : AbstractValidator<int>
    {
        private readonly Context context;
        public RemovePaymentTypeValidator(Context context)
        {
            this.context = context;
            
            RuleFor(x => x).NotEmpty().WithMessage("Id payment type is required").Must(x => context.PaymentTypes.Any(y => y.Id == x)).WithMessage("Given id does not exist");
        }
        
        public bool IsDependet(int id)
        {
            return this.context.Payments.Any(x => x.Id == id);
        }
    }
}
