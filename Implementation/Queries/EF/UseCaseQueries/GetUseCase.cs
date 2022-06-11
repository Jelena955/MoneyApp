using Application.Dto.Pagination;
using Application.Dto.UseCase;
using Application.Queries.UseCase;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.EF.UseCaseQueries
{
    public class GetUseCase : IGetUseCase
    {
        private readonly Context context;

        public GetUseCase(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 24;

        public string Name_UseCase => "Get the use cases";

        public PaginationReturn<UseCaseDto> Query(UseCaseSearch search)
        {
            var query = this.context.UseCases.AsQueryable();

            if(search.IdUseCase != 0)
            {
                query = query.Where(x => x.Id == search.IdUseCase);
            }


            return new PaginationReturn<UseCaseDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new UseCaseDto()
                {
                    IdUseCase = x.IdUseCase,
                    Name = x.Name
                }).ToList()
            };

        }
    }
}
