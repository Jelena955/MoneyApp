using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UseCase
{
    public class UpdateUseCaseDto : DtoBase
    {
        public int Id { get; set; }
        public string NewName { get; set; }
        public int IdUseCase { get; set; }
    }
}
