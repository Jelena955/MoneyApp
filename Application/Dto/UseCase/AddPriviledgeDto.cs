using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UseCase
{
    public class AddPriviledgeDto : DtoBase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }
}
