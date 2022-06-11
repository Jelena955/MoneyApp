using Application.Commands.Currency;
using Application.Dto.Currency;
using DataAccess;
using FluentValidation;
using Implementation.Validators.CurrencyValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.Currency
{
    public class UpdateCurrency : IUpdateCurrency
    {
        private readonly Context context;
        private readonly UpdateCurrencyValidator validator;

        public UpdateCurrency(Context context, UpdateCurrencyValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 12;

        public string Name_UseCase => "Updates the name of a currency";

        public void Execute(UpdateCurrencyDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objToChange = this.context.Currencys.Find(request.CurrencyId);

            objToChange.Name = request.NewName;

            this.context.SaveChanges();
        }
    }
}
