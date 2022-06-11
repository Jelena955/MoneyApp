using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.TraceObject
{
    public class GetTraceObjectDto : DtoBase
    {
        public int IdUseCase { get; set; }
        public string NameUseCase { get; set; }
        public string Response { get; set; }
        public string InputParams { get; set; }
        public string Name_LastNameUser { get; set; }
        public int IdUser { get; set; }
    }
}
