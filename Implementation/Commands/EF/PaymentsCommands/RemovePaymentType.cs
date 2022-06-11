using Application.Commands.PaymentType;
using Application.CustomExceptions;
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
    public class RemovePaymentType : IRemovePaymentType
    {
        private readonly Context context;
        private readonly RemovePaymentTypeValidator validator;

        public RemovePaymentType(Context context, RemovePaymentTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 17;

        public string Name_UseCase => "Remove payment type";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);

            if (this.validator.IsDependet(request))
            {
                throw new ConflictException("You can not delete this item, other's are depending on it");
            }

            var objToDelete = this.context.PaymentTypes.Find(request);

            objToDelete.Date_Deleted = DateTime.UtcNow;
            objToDelete.IsDeleted = true;

            this.context.SaveChanges();

        }
    }
}
