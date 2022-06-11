using Application.Dto.AccountDto;
using Application.Queries;
using Application.Searches;
using DataAccess;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetAllAccounts : IGetAllAccounts
    {
        private readonly Context context;
        
        public GetAllAccounts(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 1;

        public string Name_UseCase => "Get all accounts from DataBase";

        public ICollection<AccountInfoDto> Query(int search)
        {
            return this.context.Accounts.Where(x=>x.User.IsActive == true).Select(x => new AccountInfoDto()
            {
                AmountOfSalary = x.Salary,
                BaseCurrencyName = x.Currency.Name,
                DayOfSalary = x.RegularTimeOFSalary,
                EmailAdress = x.User.Email,
                IdAccount = x.Id,
                FirstName_LastName = x.User.Name + " " + x.User.LastName
            }).ToList();
        }
    }
}
