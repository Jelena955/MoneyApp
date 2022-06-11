using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomExceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base(message)
        {

        }
        public ConflictException(string message, BaseException innerException) : base(message, innerException)
        {

        }
    }
}
