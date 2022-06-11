using Application.Dto.AccountDto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class AddOrRemoveMoneyValidator : AbstractValidator<AddMoneyDto>
    {
        public AddOrRemoveMoneyValidator(Context context)
        {
            RuleFor(x => x.IdAccount).NotEmpty().WithMessage("Id account is manditory").Must(x => context.Accounts.Any(y => y.Id == x)).WithMessage("The given user does not exists");
            RuleFor(x => x.IdCurrency).NotEmpty().WithMessage("Currency must be selected").Must(x => context.Currencys.Any(y => y.Id == x)).WithMessage("Selected currency does not exist");
            RuleFor(x => x.HowMuchMoney).NotEmpty().WithMessage("Money is manditory").GreaterThan(0).WithMessage("Can not be negative number")
                .Must((x,y) =>
                {
                    var ret = true;
                    if (x.AddingMoney == false)
                    {
                        if(!context.MoneyOnAccounts.Any(m=> m.CurrencyId == x.IdCurrency && m.AccountId == x.IdAccount))
                        {
                            ret = false;
                        }
                    }
                    return ret;
                }).WithMessage("You can not remove money with the given currency, you dont have any money with that currency yet");
        }
    }
}
