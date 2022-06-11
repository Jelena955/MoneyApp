using Application.CustomExceptions;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.CurrencyValidators
{
    public class RemoveCurrencyValidator : AbstractValidator<int>
    {
        public RemoveCurrencyValidator(Context context)
        {
            RuleFor(x => x).NotEmpty().WithMessage("Id must not be empty").Must(x => 
            {
                if(!context.Currencys.Any(y => y.Id == x))
                {
                    throw new DoesNotExistException("Given id does not exist");
                }
                return true;
            }).Must(x => 
            {
                if (context.Accounts.Any(y => y.CurrencyId == x)) 
                {
                    throw new ConflictException("Can not delete this currency, conflict within db (Accounts table)");
                }
                return true;
            }).Must(x =>
               {
                   if (context.Payments.Any(y => y.CurrencyID == x))
                   {
                       throw new ConflictException("Can not delete this currency, conflict within db (Payments table)");
                   }
                   return true;
               });
        }
    }
}
