using Application.Commands.PaymentType;
using Application.CustomExceptions;
using Application.Dto.Payments;
using DataAccess;
using FluentValidation;
using Implementation.Validators.PaymentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.PaymentsCommands
{
    public class UpdatePaymentType : IUpdatePaymentType
    {
        private readonly Context context;
        private readonly UpdatePaymentTypeValidator validator;

        public UpdatePaymentType(Context context, UpdatePaymentTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 15;

        public string Name_UseCase => "Update the payment type";

        public void Execute(UpdatePaymentTypeDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objToChange = this.context.PaymentTypes.Find(request.IdPaymentType);

            if (request.NewCategoryID != 0)
            {
                if (this.validator.CheckCategoryID(request.NewCategoryID))
                {
                    objToChange.PaymentCategoryId = request.NewCategoryID;
                }
                else
                {
                    throw new DoesNotExistException("Category id does not exist");
                }
            }

            if (!String.IsNullOrEmpty(request.NewName))
            {
                if (this.validator.CheckNewName(request.NewName))
                {
                    objToChange.Name = request.NewName;
                }
                else
                {
                    throw new ConflictException("This name already exists");
                }
            }


            this.context.SaveChanges();

        }
    }
}
