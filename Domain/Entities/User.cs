using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string picturePath { get; set; }
        public bool IsActive { get; set; }
        public string PathForActivation { get; set; }

        public Accounts Account { get; set; }
        public List<User_UseCase> UseCases { get; set; }
        public List<TraceObjects> TraceObjects { get; set; }


    }
}
