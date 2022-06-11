using Application.Commands.Currency;
using Application.Dto.Currency;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.CurrencyValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.Currency
{
    public class AddNewCurrency : IAddNewCurrency
    {
        private readonly Context context;
        private readonly AddNewCurrencyValidator validator;

        public AddNewCurrency(Context context, AddNewCurrencyValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 10;

        public string Name_UseCase => "Adding new currency to DB";

        public void Execute(NewCurrencyDto request)
        {
            this.validator.ValidateAndThrow(request);

            var newCurrency = new Currencys()
            {
                Name = request.Name
            };

            this.context.Currencys.Add(newCurrency);

            this.context.SaveChanges();

        }
    }
}
