using Application.Commands;
using Application.Core;
using Application.Dto.UsersDto;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.UserCommands
{
    public class CreateNewUser : ICreateNewUser
    {
        private readonly Context context;
        private readonly CreateNewUserValidation validator;
        private readonly IMovePicture pictureMoover;
        private readonly IPasswordEncryptor passwordEncryptor;
        private readonly IEmailSender emailSender;

        public CreateNewUser(Context context, CreateNewUserValidation validator, IMovePicture pictureMoover, IPasswordEncryptor passwordEncryptor, IEmailSender emailSender)
        {
            this.context = context;
            this.validator = validator;
            this.pictureMoover = pictureMoover;
            this.passwordEncryptor = passwordEncryptor;
            this.emailSender = emailSender;
        }

        public int Id_UseCase => 2;

        public string Name_UseCase => "Create's the new user in the system";

        public void Execute(NewUserDto request)
        {
            this.validator.ValidateAndThrow(request);

            var pictureSrc = this.pictureMoover.movePicture(request.Picture);
            var encryptedPassword = this.passwordEncryptor.HashPassword(request.Password);
            var encryptedEmail = this.passwordEncryptor.HashPassword(request.Email);
            var activationLink = request.ServerThatHosts + "?passKey=" + encryptedPassword + encryptedEmail;

            var newAccount = new Accounts()
            {
                CurrencyId = request.IdBaseCurrency,
                RegularTimeOFSalary = request.DayOfSalary,
                Salary = request.Salary,
                LastTimeHere = DateTime.UtcNow
            };

            var ListOfAdminIds = new List<int>() { 25, 21, 26, 22, 24, 27, 28 };

            var getUseCases = this.context.UseCases.Where(x => !ListOfAdminIds.Contains(x.IdUseCase)).Select(x=> new User_UseCase() 
            {
                 UseCaseID = x.IdUseCase
            }).ToList();

            var newUser = new User()
            {
                Account = newAccount,
                Name = request.Name,
                LastName = request.LastName,
                Username = request.UserName,
                Email = request.Email,
                Password = encryptedPassword,
                picturePath = pictureSrc,
                PathForActivation = activationLink,
                UseCases = getUseCases
            };


            this.context.Users.Add(newUser);
            this.context.SaveChanges();

            this.emailSender.SendEmail("Activate account", request.Email, "Hello we are glad to have you here, here is the activation link: "+ activationLink);

               
        }
    }
}
