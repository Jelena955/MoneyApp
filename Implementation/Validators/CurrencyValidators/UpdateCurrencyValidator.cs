using Application.Dto.Currency;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.CurrencyValidators
{
    public class UpdateCurrencyValidator : AbstractValidator<UpdateCurrencyDto>
    {
        public UpdateCurrencyValidator(Context context)
        {
            RuleFor(x => x.NewName).NotEmpty().WithMessage("New name is manditory").Must(x => !context.Currencys.Any(y => y.Name == x)).WithMessage("That name is taken");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency id not supplied").Must(x => context.Currencys.Any(y => y.Id == x)).WithMessage("Currency does not exist");
        }
    }
}
