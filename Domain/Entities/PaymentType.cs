using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentType : EntityBase
    {
        public int PaymentCategoryId { get; set; }
        public string Name { get; set; }

        public List<Payments> Payments { get; set; }
        public PaymentCategory PaymentCategory { get; set; }
    }
}
