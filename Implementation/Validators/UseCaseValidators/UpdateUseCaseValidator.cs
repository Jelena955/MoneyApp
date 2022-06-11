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
    public class UpdateUseCaseValidator : AbstractValidator<UpdateUseCaseDto>
    {
        private readonly Context context;
        public UpdateUseCaseValidator(Context context)
        {
            this.context = context;
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is manditory").Must(x => context.UseCases.Any(y => y.IdUseCase == x)).WithMessage("Provided id does not exist");
        }
        public bool checkName(string newName)
        {
            return !context.UseCases.Any(x => x.Name == newName);
        }
        public bool checkId(int newId)
        {
            return !context.UseCases.Any(x => x.IdUseCase == newId);
        }
    }
}
