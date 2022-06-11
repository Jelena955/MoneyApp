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
    public class AddSalaryValidator : AbstractValidator<int>
    {
        public AddSalaryValidator(Context context)
        {
            RuleFor(x => x).NotEmpty().WithMessage("Id account is empty").Must(x => context.Accounts.Any(y => y.Id == x)).WithMessage("User id not found");
        }
    }
}
