using Application.Dto.UseCase;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.UseCaseValidators
{
    public class AddUseCasePriviledgeValidator: AbstractValidator<AddPriviledgeDto>
    {
        public AddUseCasePriviledgeValidator(Context context)
        {
            RuleFor(x => x.UseCaseId).NotEmpty().WithMessage("UseCaseId is manditory").Must(x => context.UseCases.Any(y => y.IdUseCase == x)).WithMessage("There are no useCase").Must((x, z) =>
            {
                return !context.UserUseCases.Any(y => y.UserId == x.UserId && y.UseCaseID == z);
            }).WithMessage("User already have that priviledge");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id is manditory").Must(x => context.Users.Any(y => y.Id == x)).WithMessage("That user does not exist");
        }
    }
}
