using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorProblem
{
    using System;

    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_USERID
        }

        public ExceptionType type;

        public CabInvoiceException(string message, ExceptionType type)
            : base(message)
        {
            this.type = type;
        }
    }
}