using System;
using System.Collections.Generic;
using System.Text;

namespace Fishare.Logic
{
    public class ExceptionHandler : Exception
    {
        /// <summary>
        /// This property is used by the ASP.NET Constructor
        /// </summary>
        public string Index { get; private set; }

        /// <summary>
        /// This constructure is for APS.NET ViewData[]
        /// </summary>
        /// <param name="index"></param>
        /// <param name="message"></param>
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
