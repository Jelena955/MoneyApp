using Application.Core;
using Application.Dto.Pagination;
using Application.Dto.TraceObject;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TraceObject
{
    public interface IGetTraceObjects : IQuery<TraceObjectSearch,PaginationReturn<GetTraceObjectDto>>
    {
    }
}
