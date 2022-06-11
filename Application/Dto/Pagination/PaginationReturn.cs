using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Pagination
{
    public class PaginationReturn<Dto> : DtoBase
        where Dto : DtoBase
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((float)this.TotalCount / this.PerPage);
        public ICollection<Dto> Data { get; set; }
    }
}
