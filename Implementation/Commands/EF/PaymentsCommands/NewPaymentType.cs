using Application.Commands.PaymentType;
using Application.Dto.Payments;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.PaymentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.PaymentsCommands
{
    public class NewPaymentType : INewPaymentType
    {
        private readonly Context context;
        private readonly NewPaymentTypeValidator validator;

        public NewPaymentType(Context context, NewPaymentTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 14;

        public string Name_UseCase => "Adding new payment type";

        public void Execute(NewPaymentTypeDto request)
        {
            this.validator.ValidateAndThrow(request);

            var newObject = new PaymentType()
            {
                Name = request.Name,
                PaymentCategoryId = request.CategoryId
            };
            this.context.PaymentTypes.Add(newObject);

            this.context.SaveChanges();
        }
    }
}
