using Application.Core;
using Application.Dto.Pagination;
using Application.Dto.UseCase;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UseCase
{
    public interface IPreviewAllPriveledgesForuser : IQuery<PreviewUseCasePriviledges, PaginationReturn<PreviewPriviledgeDto>>
    {
    }
}
