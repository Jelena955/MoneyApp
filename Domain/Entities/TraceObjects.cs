using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TraceObjects : EntityBase
    {
        public int UseCaseId { get; set; }
        public string Response { get; set; }
        public int UserId { get; set; }
        public string UserIdentity { get; set; }
        public string NameUseCase { get; set; }
        public string InputParameters { get; set; }

        public Use_Cases UseCase { get; set; }
        public User User { get; set; }
    }
}
