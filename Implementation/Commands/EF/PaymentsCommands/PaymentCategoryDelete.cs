using Application.Commands.PaymentCategory;
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
    public class PaymentCategoryDelete : IPaymentCategoryDelete
    {
        private readonly Context context;
        private readonly PaymentCategoryDeleteValidation validator;

        public PaymentCategoryDelete(Context context, PaymentCategoryDeleteValidation validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 9;

        public string Name_UseCase => "Deleting payment category";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);

            var objToDelete = this.context.PaymentCategories.Find(request);

            objToDelete.Date_Deleted = DateTime.UtcNow;
            objToDelete.IsDeleted = true;

            this.context.SaveChanges();

        }
    }
}
