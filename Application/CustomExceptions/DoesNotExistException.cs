using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomExceptions
{
    public class DoesNotExistException : BaseException
    {
        public DoesNotExistException(string message) : base(message)
        {

        }
    }
}
