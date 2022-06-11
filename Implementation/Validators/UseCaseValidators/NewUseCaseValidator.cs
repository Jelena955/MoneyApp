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
    public class NewUseCaseValidator : AbstractValidator<NewUseCaseDto>
    {
        public NewUseCaseValidator(Context context)
        {
            RuleFor(x => x.IdUseCase).NotEmpty().WithMessage("Id use case is manditory").Must(x => !context.UseCases.Any(y => y.IdUseCase == x)).WithMessage("That usecase id is already taken");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is manditory").Must(x => !context.UseCases.Any(y => y.Name == x)).WithMessage("That use case nam is taken");
        }
    }
}
