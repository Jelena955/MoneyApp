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
    public class NewPaymentValidator : AbstractValidator<NewPaymentDto>
    {
        public NewPaymentValidator(Context context)
        {

            RuleFor(x => x.PaymentTypeId).NotEmpty().WithMessage("Payment type is manditory").Must(x => context.PaymentTypes.Any(y => y.Id == x)).WithMessage("Given payment type id does not exist");
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Account id is manditory").Must(x => context.Accounts.Any(y => y.Id == x)).WithMessage("Given account id does not exist");
            RuleFor(x => x.AmountPaid).NotEmpty().WithMessage("How much are you paying is not specified").GreaterThan(0).WithMessage("Amount paid must be greater than 0");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency id is manditory").Must(x => context.Currencys.Any(y => y.Id == x)).WithMessage("Given currency does not exist").Must((x, z) => context.MoneyOnAccounts.Any(y => y.AccountId == x.AccountId && y.CurrencyId == z)).WithMessage("The user does not have specified currency").Must((x, z) =>
            {
                var ret = true;
                var MoneyOfThatCur = context.MoneyOnAccounts.Where(y => y.AccountId == x.AccountId && y.CurrencyId == z).Select(x => x.Amount).FirstOrDefault();
                if (MoneyOfThatCur < x.AmountPaid)
                {
                    ret = false;
                }
                return ret;
            }).WithMessage("You dont have enough money to pay with that currency");

        }
    }
}
