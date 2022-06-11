using Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class TraceObjectSearch : PaginationSearch
    {
        public int IdUser { get; set; }
        public int IdUseCase { get; set; }
        public bool? Success { get; set; }
    }
}
