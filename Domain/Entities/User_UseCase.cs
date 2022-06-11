using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User_UseCase : EntityBase
    {
        public int UserId { get; set; }
        public int UseCaseID { get; set; }

        public User User { get; set; }
        public Use_Cases UseCase { get; set; }
    }
}
