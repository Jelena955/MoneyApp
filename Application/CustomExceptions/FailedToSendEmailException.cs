﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomExceptions
{
    public class FailedToSendEmailException: BaseException
    {
        public FailedToSendEmailException(string message) : base(message)
        {
        }
        public FailedToSendEmailException(string message,Exception innerException):base(message, innerException)
        {
        }
    }
}
