using Application.Commands.UseCase;
using Application.Dto.UseCase;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.UseCaseValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.UseCaseCommands
{
    public class NewUseCase : INewUseCase
    {
        private readonly Context context;
        private readonly NewUseCaseValidator validator;

        public NewUseCase(Context context, NewUseCaseValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 21;

        public string Name_UseCase => "Add new UseCase to system";

        public void Execute(NewUseCaseDto request)
        {
            this.validator.ValidateAndThrow(request);

            var newObj = new Use_Cases()
            {
                Name = request.Name,
                IdUseCase = request.IdUseCase
            };

            this.context.UseCases.Add(newObj);
            this.context.SaveChanges();

        }
    }
}
