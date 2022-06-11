using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UserActivationValidation : AbstractValidator<string>
    {
        public UserActivationValidation(Context context)
        {
            RuleFor(x => x).NotNull().WithMessage("User key can not be null").NotEmpty().WithMessage("Given string is empty").Must(x => context.Users.Any(y => y.PathForActivation == x)).WithMessage("Activation code does not exists");
        }
    }
}
