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
    public class AddNewCurrencyValidator : AbstractValidator<NewCurrencyDto>
    {
        public AddNewCurrencyValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of currency is requierd").Must(x => !context.Currencys.Any(y => y.Name == x)).WithMessage("That name already exists");
        }
    }
}
