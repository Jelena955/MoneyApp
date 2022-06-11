using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payments
{
    public class  UpdatePaymentCategoryDto: DtoBase
    {
        public int IdPaymentCategory { get; set; }
        public string NewNameCategory { get; set; }
    }
}
