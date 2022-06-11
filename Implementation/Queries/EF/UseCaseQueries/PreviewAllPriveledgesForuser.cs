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
    public class PreviewAllPriveledgesForuser : IPreviewAllPriveledgesForuser
    {
        private readonly Context context;

        public PreviewAllPriveledgesForuser(Context context)
        {
            this.context = context;
        }

        public int Id_UseCase => 27;

        public string Name_UseCase => "Prieviewing use case priviledges";

        public PaginationReturn<PreviewPriviledgeDto> Query(PreviewUseCasePriviledges search)
        {
            var query = this.context.Users.AsQueryable();

            if (search.IdUserId != 0) 
            {
                query = query.Where(x => x.Id == search.IdUserId);
            }


            return new PaginationReturn<PreviewPriviledgeDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new PreviewPriviledgeDto()
                {
                    IdUser = x.Id,
                    Name_LastName = x.Name + " " + x.LastName,
                    UseCases = x.UseCases.Select(y => new _useCaseInner()
                    {
                        IdUseCase = y.UseCaseID,
                        NameUseCase = y.UseCase.Name
                    }).ToList()
                }).ToList()
            };
        }
    }
}
