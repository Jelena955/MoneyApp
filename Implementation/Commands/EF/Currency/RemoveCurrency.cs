using Application.Commands.Currency;
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
    public class RemoveCurrency : IRemoveCurrency
    {
        private readonly Context context;
        private readonly RemoveCurrencyValidator validator;

        public RemoveCurrency(Context context, RemoveCurrencyValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 13;

        public string Name_UseCase => "Removes the currency";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);
            var objToDelete = this.context.Currencys.Find(request);

            objToDelete.IsDeleted = true;
            objToDelete.Date_Deleted = DateTime.UtcNow;

            this.context.SaveChanges();
        }
    }
}
