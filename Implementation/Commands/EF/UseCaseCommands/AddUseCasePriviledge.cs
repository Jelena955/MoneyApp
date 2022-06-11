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
    public class AddUseCasePriviledge : IAddUseCasePriviledge
    {
        private readonly Context context;
        private readonly AddUseCasePriviledgeValidator validator;

        public AddUseCasePriviledge(Context context, AddUseCasePriviledgeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 25;

        public string Name_UseCase => "Adding user use case priviledge";

        public void Execute(AddPriviledgeDto request)
        {
            this.validator.ValidateAndThrow(request);

            var newObj = new User_UseCase()
            {
                UseCaseID = request.UseCaseId,
                UserId = request.UserId
            };

            this.context.UserUseCases.Add(newObj);
            this.context.SaveChanges();
        }
    }
}
