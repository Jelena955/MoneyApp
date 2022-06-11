using Application.Core;
using Application.Searches;
using Application.Dto.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IGetAllAccounts : IQuery<int, ICollection<AccountInfoDto>>
    {
    }
}
