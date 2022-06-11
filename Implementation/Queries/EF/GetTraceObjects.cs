using Application.Dto.Pagination;
using Application.Dto.TraceObject;
using Application.Queries.TraceObject;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF
{
    public class GetTraceObjects : IGetTraceObjects
    {
        private readonly Context context;

        public GetTraceObjects(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 28;

        public string Name_UseCase => "Get trace objects";

        public PaginationReturn<GetTraceObjectDto> Query(TraceObjectSearch search)
        {
            var query = this.context.TraceObjects.AsQueryable();

            if (search.Success !=null) 
            {
                query = (bool)search.Success ? query.Where(x => x.Response == "Success") : query.Where(x => x.Response == "Error");
            }

            if (search.IdUseCase != 0)
            {
                query = query.Where(x => x.UseCaseId == search.IdUseCase);
            }
            if (search.IdUser != 0) 
            {
                query = query.Where(x => x.UserId == search.IdUser);
            }


            return new PaginationReturn<GetTraceObjectDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new GetTraceObjectDto()
                {
                    IdUseCase = x.UseCaseId,
                    IdUser = x.UserId,
                    InputParams = x.InputParameters,
                    NameUseCase = x.NameUseCase,
                    Name_LastNameUser = x.User.Name + " " + x.User.LastName,
                    Response = x.Response
                }).ToList()
            };
        }
    } 
}
