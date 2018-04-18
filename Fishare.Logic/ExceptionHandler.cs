using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Logic
{
    public class ExceptionHandler : Exception
    {
        public string Index { get; private set; }

        public ExceptionHandler(string index, string message)
            : base(message)
        {
            Index = index;
        }

        public ExceptionHandler(string message)
            : base(message) { }

        public ExceptionHandler(string format, params object[] args)
            : base(string.Format(format, args)) { }
    }
}
