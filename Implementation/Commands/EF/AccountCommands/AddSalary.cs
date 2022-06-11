using Application.Commands.Account;
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
    public class AddSalary : IAddSalary
    {
        private readonly Context context;
        private readonly AddSalaryValidator validator;
        private readonly IAddOrRemoveMoneyToAccount MoneyAdder;

        public AddSalary(Context context, AddSalaryValidator validator, IAddOrRemoveMoneyToAccount moneyAdder)
        {
            this.context = context;
            this.validator = validator;
            MoneyAdder = moneyAdder;
        }

        public int Id_UseCase => 29;

        public string Name_UseCase => "Adding salary";

        public void Execute(int request)
        {
            this.validator.ValidateAndThrow(request);

            var objToChangeAccount = this.context.Accounts.Find(request);
            var monthsNotHere = ((DateTime.UtcNow.Year - objToChangeAccount.LastTimeHere.Year) * 12) + DateTime.UtcNow.Month - objToChangeAccount.LastTimeHere.Month;
            
            if (monthsNotHere > 0)
            {
                var SalaryUpdated = false;
                var listOf31Days = new List<int>() { 1, 3, 5, 7,8, 10, 12 };
                if(DateTime.UtcNow.Day >= objToChangeAccount.RegularTimeOFSalary)
                {
                    this.addingMoney(objToChangeAccount, monthsNotHere);

                    SalaryUpdated = true;
                }
                
                if (SalaryUpdated != true && objToChangeAccount.RegularTimeOFSalary == 31 && (DateTime.UtcNow.Day == 30 && (listOf31Days.Contains(DateTime.UtcNow.Month)))) 
                {
                    this.addingMoney(objToChangeAccount, monthsNotHere);

                    SalaryUpdated = true;
                }
                if (SalaryUpdated != true && (objToChangeAccount.RegularTimeOFSalary == 31 || objToChangeAccount.RegularTimeOFSalary == 30 || objToChangeAccount.RegularTimeOFSalary == 29) && (((DateTime.UtcNow.Day == 29 || DateTime.UtcNow.Day == 28)  && (DateTime.UtcNow.Month == 2)))) 
                {
                    this.addingMoney(objToChangeAccount, monthsNotHere);

                    SalaryUpdated = true;
                }
            }
            objToChangeAccount.LastTimeHere = DateTime.UtcNow;
            this.context.SaveChanges();
        }

        private void addingMoney(Accounts obj,int monthNotHere)
        {
            var newadd = new AddMoneyDto()
            {
                AddingMoney = true,
                IdAccount = obj.Id,
                IdCurrency = obj.CurrencyId,
                HowMuchMoney = monthNotHere * obj.Salary,
            };
            this.MoneyAdder.Execute(newadd);
        }

    }
}
