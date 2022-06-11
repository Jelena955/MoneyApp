using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Use_Cases : EntityBase
    {
        public string Name { get; set; }
        public int IdUseCase { get; set; }

        public List<User_UseCase> UserUseCases { get; set; }
        public List<TraceObjects> TraceObjects { get; set; }
    }
}
