using Application.Commands.PaymentCategory;
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
    public class UpdatePaymentCategory : IUpdatePaymentCategory
    {
        private readonly Context context;
        private readonly UpdatePaymentCategoryValidator validator;

        public UpdatePaymentCategory(Context context, UpdatePaymentCategoryValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 8;

        public string Name_UseCase => "Update payment category";

        public void Execute(UpdatePaymentCategoryDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objectToChange = this.context.PaymentCategories.Find(request.IdPaymentCategory);

            objectToChange.Name = request.NewNameCategory;

            this.context.SaveChanges();
        }
    }
}
