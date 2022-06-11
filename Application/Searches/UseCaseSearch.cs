using Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class UseCaseSearch : PaginationSearch
    {
        public int IdUseCase { get; set; }
    }
}
