using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UseCase
{
    public class PreviewPriviledgeDto : DtoBase
    {
        public int IdUser { get; set; }
        public string Name_LastName { get; set; }
        public IEnumerable<_useCaseInner> UseCases { get; set; }
    }

    public class _useCaseInner
    {
        public int IdUseCase { get; set; }
        public string NameUseCase { get; set; }

    }
}
