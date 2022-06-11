using Application.Commands.PaymentCategory;
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
    public class NewPaymentCategory : INewPaymentCategory
    {
        private readonly Context context;
        private readonly NewPaymentCategoryValidator validator;

        public NewPaymentCategory(Context context, NewPaymentCategoryValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 6;

        public string Name_UseCase => "Create new payment category";

        public void Execute(NewPaymentCategoryDto request)
        {
            this.validator.ValidateAndThrow(request);

            var newPaymentCategory = new PaymentCategory()
            {
                Name = request.Name
            };

            this.context.PaymentCategories.Add(newPaymentCategory);
            this.context.SaveChanges();
        }
    }
}
