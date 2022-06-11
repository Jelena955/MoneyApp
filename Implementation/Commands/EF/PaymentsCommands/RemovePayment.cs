using Application.Commands.Payments;
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
    public class RemovePayment : IRemovePayment
    {
        private readonly Context Context;
        private readonly RemovePaymentValidator validator;
        public RemovePayment(Context context, RemovePaymentValidator validator)
        {
            Context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 23;

        public string Name_UseCase => "Remove payment";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);

            var objToDelete = this.Context.Payments.Find(request);

            objToDelete.IsDeleted = true;
            objToDelete.Date_Deleted = DateTime.UtcNow;

            this.Context.SaveChanges();
        }
    }
}
