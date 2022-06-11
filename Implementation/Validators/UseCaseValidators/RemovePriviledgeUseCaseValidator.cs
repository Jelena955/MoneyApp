using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UseCaseValidators
{
    public class RemovePriviledgeUseCaseValidator : AbstractValidator<int>
    {
        public RemovePriviledgeUseCaseValidator(Context context)
        {
            RuleFor(x => x).Must(x => context.UserUseCases.Any(y => y.Id == x)).WithMessage("Id of priviledge not found").OverridePropertyName("IdPriviledge").NotEmpty().WithMessage("Priviledge id is manditory").OverridePropertyName("IdPriviledge"); 

        }
    }
}
