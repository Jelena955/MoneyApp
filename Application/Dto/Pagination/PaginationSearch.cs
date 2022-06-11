using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Pagination
{
    public class PaginationSearch :BaseSearch
    {
        public int PerPage { get; set; } = 3;
        public int Page { get; set; } = 1;
    }
}
