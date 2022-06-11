using Application.Commands.UseCase;
using DataAccess;
using FluentValidation;
using Implementation.Validators.UseCaseValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.UseCaseCommands
{
    public class RemovePriviledgeUseCase : IRemovePriviledgeUseCase
    {
        private readonly Context context;
        private readonly RemovePriviledgeUseCaseValidator validator;

        public RemovePriviledgeUseCase(Context context, RemovePriviledgeUseCaseValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 26;

        public string Name_UseCase => "Remove's the priviledge from user";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);

            var objToRemove = this.context.UserUseCases.Find(request);

            objToRemove.IsDeleted = true;
            objToRemove.Date_Deleted = DateTime.UtcNow;

            this.context.SaveChanges();
        }
    }
}
