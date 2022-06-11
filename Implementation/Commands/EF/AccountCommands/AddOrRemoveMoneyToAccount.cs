using Application.Commands.Account;
using Application.CustomExceptions;
using Application.Dto.AccountDto;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.EF.AccountCommands
{
    public class AddOrRemoveMoneyToAccount : IAddOrRemoveMoneyToAccount
    {
        private readonly Context context;
        private readonly AddOrRemoveMoneyValidator validator;

        public AddOrRemoveMoneyToAccount(Context context, AddOrRemoveMoneyValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id_UseCase => 4;

        public string Name_UseCase => "Adding money to account";

        public void Execute(AddMoneyDto request)
        {
            this.validator.ValidateAndThrow(request);

            var objectToCheck = this.context.MoneyOnAccounts.Any(x => x.AccountId == request.IdAccount && x.CurrencyId == request.IdCurrency);

            if (objectToCheck)
            {
                var changeMoney = this.context.MoneyOnAccounts.First(x => x.AccountId == request.IdAccount && x.CurrencyId == request.IdCurrency);
                changeMoney.Amount = request.AddingMoney ? changeMoney.Amount + request.HowMuchMoney : (changeMoney.Amount - request.HowMuchMoney) > 0 ? changeMoney.Amount - request.HowMuchMoney : throw new NegativeNumberException("You can not remove more money than you have") ;
            }
            else
            {
                var newMoney = new MoneyOnAccounts()
                {
                    AccountId = request.IdAccount,
                    Amount = request.HowMuchMoney,
                    CurrencyId = request.IdCurrency,
                };
                this.context.MoneyOnAccounts.Add(newMoney);
            }
            this.context.SaveChanges();
        }
    }
}
