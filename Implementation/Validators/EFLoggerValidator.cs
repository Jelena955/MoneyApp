using Application.Core;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class EFLoggerValidator : AbstractValidator<IUseCase>
    {
        public EFLoggerValidator(Context context)
        {
            RuleFor(x => x.Id_UseCase).NotEmpty().WithMessage("Id use case is requred").Must(x => context.UseCases.Any(y => y.IdUseCase == x)).WithMessage("Id use case does not exist");
            RuleFor(x => x.Name_UseCase).NotEmpty().WithMessage("Name is required");
        }
    }
}
