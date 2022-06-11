using Application.Commands.User;
using Application.Core;
using Application.CustomExceptions;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.UserCommands
{
    public class ActivateUser : IActivateUser
    {
        private readonly Context context;
        private readonly UserActivationValidation validatior;

        public ActivateUser(Context context, IPasswordEncryptor passwordEncryptor, UserActivationValidation validatior)
        {
            this.context = context;
            this.validatior = validatior;
        }

        public int Id_UseCase => 3;

        public string Name_UseCase => "Activating the user account";

        public void Execute(string request)
        {
            this.validatior.ValidateAndThrow(request);

            var userForActivating = this.context.Users.First(x => x.PathForActivation == request);

            if(userForActivating.IsActive == true)
            {
                throw new UserAlredyActiveException("User is already active");
            }

            userForActivating.IsActive = true;

            this.context.SaveChanges();

        }
    }
}
