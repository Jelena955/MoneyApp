using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class UpdatePaymentTypeDto : DtoBase
    {
        public string NewName { get; set; }
        public int NewCategoryID { get; set; }
        public int IdPaymentType { get; set; }
    }
}
