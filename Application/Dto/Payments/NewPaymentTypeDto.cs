using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class NewPaymentTypeDto : DtoBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
