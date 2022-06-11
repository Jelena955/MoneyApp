using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto.Pagination;
using Application.Dto.UseCase;
using Application.Searches;

namespace Application.Queries.UseCase
{
    public interface IGetUseCase : IQuery<UseCaseSearch,PaginationReturn<UseCaseDto>>
    {
    }
}
