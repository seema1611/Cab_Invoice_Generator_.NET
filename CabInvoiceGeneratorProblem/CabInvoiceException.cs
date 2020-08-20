// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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