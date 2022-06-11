using Application.Commands.UseCase;
using Application.CustomExceptions;
using Application.Dto.UseCase;
using DataAccess;
using FluentValidation;
using Implementation.Validators.UseCaseValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.UseCaseValidators
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly Context context;
        private readonly UpdateUseCaseValidator validator;

        public UpdateUseCase(Context context, UpdateUseCaseValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 22;

        public string Name_UseCase => "Updatates the useCase";

        public void Execute(UpdateUseCaseDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objToChange = this.context.UseCases.Find(request.Id);

            if(request.IdUseCase != 0)
            {
                if (this.validator.checkId(request.IdUseCase))
                {
                    objToChange.IdUseCase = request.IdUseCase;
                }
                else 
                {
                    throw new DoesNotExistException("Provided idUseCase is already take");
                }
            }
            if (!String.IsNullOrEmpty(request.NewName))
            {
                if (this.validator.checkName(request.NewName))
                {
                    objToChange.Name = request.NewName;
                }
                else
                {
                    throw new ConflictException("Provided name already taken");
                }
            }

            this.context.SaveChanges();
        }
    }
}
