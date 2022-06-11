using Application.Commands.Payments;
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
    public class NewPayment : INewPayment
    {
        private readonly Context context;
        private readonly NewPaymentValidator validator;

        public NewPayment(Context context, NewPaymentValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 18;

        public string Name_UseCase => "Making new payment";

        public void Execute(NewPaymentDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objToChange = this.context.MoneyOnAccounts.Where(x => x.AccountId == request.AccountId && x.CurrencyId == request.CurrencyId).Select(x => x).First();

            objToChange.Amount -= request.AmountPaid;

            var newPayment = new Payments()
            {
                AccountId = request.AccountId,
                CurrencyID = request.CurrencyId,
                PaymentTypeId = request.PaymentTypeId,
                Amount = request.AmountPaid
            };

            this.context.Payments.Add(newPayment);

            this.context.SaveChanges();
        }
    }
}
